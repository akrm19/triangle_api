using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriangleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrianglesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public ActionResult<string> Get([FromQuery]TriangleCoordinate coordinate)
        {
            try
            {
                var temp = $"coodinate: col:{coordinate.Column}, row:{coordinate.Row}";
                return Ok(temp);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error occured: {e.Message}");
            }
        }
    }
}
