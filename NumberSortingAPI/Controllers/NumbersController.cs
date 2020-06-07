using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberSortingAPI.Domain;
using NumberSortingAPI.Services;

namespace NumberSortingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class NumbersController : ControllerBase
    {
        private readonly INumbersService _numbersService;

        public NumbersController(INumbersService numbersService)
        {
            _numbersService = numbersService;
        }
        
        // GET api/numbers
        [HttpGet]
        public ActionResult<Numbers> Get()
        {
            try
            {
                int[] numbers = _numbersService.GetNumbers();
                
                return Ok(new Numbers { Values = numbers });
            }
            catch (FileNotFoundException)
            {
                return NotFound("File does not exist.");
            }
        }
        
        // POST api/numbers
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                var inputString = await reader.ReadToEndAsync();
                
                if (StringFormatIsValid(inputString))
                {
                    int[] integerArray = GetIntArrayFromInputString(inputString);
                    _numbersService.SortNumbers(integerArray);
                    _numbersService.WriteNumbers(integerArray);
                
                    return Created("api/numbers", new Numbers { Values = integerArray });
                }
                
                return BadRequest("The input format is incorrect.");
            }
        }
        
        public bool StringFormatIsValid(string inputString)
        {
            return !string.IsNullOrEmpty(inputString) && inputString.All(c => (c >= '0' && c <= '9') || c == ' ' || c == '-');
        }

        public int[] GetIntArrayFromInputString(string inputString)
        {
            int[] integers = inputString
                .Split(' ')
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Select(int.Parse)
                .ToArray();

            return integers;
        }
    }
}