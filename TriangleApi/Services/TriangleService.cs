using System;
using System.Collections.Generic;
using System.Linq;
using TriangleApi.Models;

namespace TriangleApi.Services
{
    public class TriangleService : ITriangeService
    {
        private int _imgSize, _sqrSize;

        public TriangleService(int imageSize = 60, int squareSize = 10)
        {
            _imgSize = imageSize;
            _sqrSize = squareSize;
        }

        private int ColumnCount()
        {
            return _imgSize / (_sqrSize / 2);
        }

        private int RowCount()
        {
            return _imgSize / _sqrSize;
        }

        public TriangleVertices GetVerticesForCoordinate(TriangleCoordinate coordinate)
        {
            //Check if coordinate is valid:
            if (coordinate == null || CharToNum(coordinate.Row) > RowCount() || coordinate.Column > ColumnCount()
                || coordinate.Column < 0)
                return null;

            //Odds are at the bottom of the sqr
            var isTop = coordinate.Column % 2 == 0;

            //top-left vertex:
            int topLeftX = (int)(Math.Ceiling(coordinate.Column / 2d) - 1) * _sqrSize;
            var topLeftY = _imgSize - ((CharToNum(coordinate.Row) - 1) * _sqrSize);

            //bottom-right vertex
            var bottomRightX = (int)Math.Ceiling(coordinate.Column / 2d) * _sqrSize;
            var bottomRightY = _imgSize - (CharToNum(coordinate.Row) * _sqrSize);

            //right-angle vertex
            var midX = isTop ? bottomRightX : topLeftX;
            var midY = isTop ? topLeftY : bottomRightY;

            return new TriangleVertices(
                topLeftX, topLeftY,
                bottomRightX, bottomRightY,
                midX, midY);
        }

        public TriangleCoordinate GetCoordinateFromVertices(TriangleVertices vertices)
        {
            if (!AreValidVertices(vertices))
                return null;

            var isTop = vertices.TopLeftY == vertices.MiddleY;

            int col = ((vertices.MiddleX / 10) * 2) + (isTop ? 0 : 1);
            int rowNum = (_imgSize - vertices.BottomRightY) / _sqrSize;
            char row = NumToChar(rowNum);

            return new TriangleCoordinate(row, col);
        }

        private int CharToNum(char c)
        {
            return char.ToUpper(c) - 64;
        }

        private char NumToChar(int position)
        {
            return (char)(65 + (position - 1));
        }

        private bool AreValidVertices(TriangleVertices vrtx)
        {
            if (vrtx == null) return false;

            var vertices = new List<int> { vrtx.TopLeftX, vrtx.TopLeftY, vrtx.MiddleX, vrtx.MiddleY, vrtx.BottomRightX, vrtx.BottomRightY };

            if (vertices.Count != 6)
                return false;

            return !vertices.Any(v => v < 0 || v > _imgSize || v % _sqrSize != 0);
        }
    }
}
