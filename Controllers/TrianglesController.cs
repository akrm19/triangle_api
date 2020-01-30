using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleApi.Models;
using TriangleApi.Services;

namespace TriangleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrianglesController : Controller
    {
        private ITriangeService _helper;

        public TrianglesController(ITriangeService triangeService)
        {
            _helper = triangeService;

        }

        [HttpGet("{row}/{column}")]
        public ActionResult<TriangleVertices> GetVertices([FromRoute]TriangleCoordinate coordinate)
        {
            try
            {
                var result = _helper.GetVerticesForCoordinate(coordinate);

                if (result == null)
                    return BadRequest("No triangle found with given coordinate");

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error occured: {e.Message}");
            }
        }

        //api/triangles/Coordinates
        [HttpGet("Coordinates")]
        public ActionResult<TriangleCoordinate> GetCoordinate2([FromQuery]TriangleVertices vertices)
        {
            try
            {
                var result = _helper.GetCoordinateFromVertices(vertices);

                if (result == null)
                    return BadRequest("Invalid vertices. Unable to find traingle coordinate");

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error occured: {e.Message}");
            }
        }
    }
}
