using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleApi.Models;
using TriangleApi.Utils;

namespace TriangleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrianglesController : Controller
    {
        private TriangleHelper _helper;

        public TrianglesController()
        {
            _helper = new TriangleHelper();
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


                //api/triangles/Coordinates
        [HttpGet("test")]
        public ActionResult<TriangleCoordinate> GetTest([FromQuery]TriangleVertices vertices)
        {
            try
            {
                return Ok("OK Test");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error occured: {e.Message}");
            }
        }
    }
}
