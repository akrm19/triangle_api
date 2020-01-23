using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleApi.Models;
using TriangleApi.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet]
        public ActionResult<TriangleVertices> Get([FromQuery]TriangleCoordinate coordinate)
        {
            try
            {
                var result = _helper.GetVerticesForCoordinate(coordinate);

                if (result == null)
                    return BadRequest("No triangle found with given coordinate");

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error occured: {e.Message}");
            }
        }

        //api/triangles/Coordinate
        [HttpGet("Coordinate")]
        public ActionResult<TriangleCoordinate> GetCoordinate2([FromQuery]TriangleVertices vertices)
        {
            try
            {
                var result = _helper.GetCoordinateFromVertices(vertices);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error occured: {e.Message}");
            }
        }
    }
}
