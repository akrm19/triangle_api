using System;
using TriangleApi.Models;
using TriangleApi.Services;
using Xunit;

namespace TriangleApi.Tests
{
    public class TriangleServiceTests
    {
        [Fact]
        public void IsResultValid_CoordinatesFromVertices_EmptyInput()
        {
            var service = new TriangleService();
            var result = service.GetCoordinateFromVertices(null);
            Assert.Null(result);
        }

        [Fact]
        public void IsResultValid_CoordinatesFromVertices_InvalidInput()
        {
            var service = new TriangleService();
            var input = new TriangleVertices(-2, -2, -2, -2, -2, -2);
            var result = service.GetCoordinateFromVertices(input);
            Assert.Null(result);
        }        [Fact]        public void IsResultValid_VerticesFromCoordinates_InvalidInput()
        {
            var service = new TriangleService();
            var input = new TriangleCoordinate('z', 2);
            var result = service.GetVerticesForCoordinate(input);
            Assert.Null(result);

            input = new TriangleCoordinate('a', -2);
            result = service.GetVerticesForCoordinate(input);
            Assert.Null(result);
        }    }
}
