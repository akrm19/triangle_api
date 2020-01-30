using System;
using TriangleApi.Models;

namespace TriangleApi.Services
{
    public interface ITriangeService
    {
        TriangleVertices GetVerticesForCoordinate(TriangleCoordinate coordinate);

        TriangleCoordinate GetCoordinateFromVertices(TriangleVertices vertices);
    }
}
