using Microsoft.AspNetCore.Mvc;
using NumberSortingAPI.Domain;

namespace NumberSortingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumbersController : ControllerBase
    {
        // GET api/numbers
        [HttpGet]
        public ActionResult<Numbers> Get()
        {
            return Ok();
        }
        
        // POST api/numbers
        [HttpPost]
        public ActionResult Post([FromBody] Numbers numbers)
        {
            return Created("api/numbers", new Numbers{ Values = numbers.Values });
        }
    }
}