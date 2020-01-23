using System;
using TriangleApi.Models;

namespace TriangleApi.Utils
{
    public class TriangleHelper
    {
        private int _imgSize, _sqrSize;

        public TriangleHelper(int imageSize = 60, int squareSize = 10)
        {
            _imgSize = imageSize;
            _sqrSize = squareSize;
        }

        private int ColumnCount()
        {
            return _imgSize / (_sqrSize/2);
        }

        private int RowCount()
        {
            return _imgSize / _sqrSize;
        }

        public TriangleVertices GetVerticesForCoordinate(TriangleCoordinate coordinate)
        {
            //Check if coordinate is valid:
            if (CharToNum(coordinate.Row) > RowCount() || coordinate.Column > ColumnCount())
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
                topLeftX,topLeftY,
                bottomRightX, bottomRightY,
                midX, midY);
        }

        private int CharToNum(char c)
        {
            return char.ToUpper(c) - 64;
        }
    }
}
