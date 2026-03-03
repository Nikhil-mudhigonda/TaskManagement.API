using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using TaskManagement.API.DTOs.JSONLearning;

namespace TaskManagement.API.Controllers
{
    public class JsonController : ControllerBase
    {
        [HttpGet("GetName")]
        public IActionResult GetName(jsonLearning jsonstring)
        {
            var result = new jsonLearning
            {
                Name = jsonstring.Name,
                age = jsonstring.age
            };
            return Ok($"Hello {result.Name},{result.age}!");
        }

        [HttpGet("GetEnum")]
        public IActionResult GetEnum(JsonEnum enumInJson)
        {
            var result = new JsonEnum
            {
                Status = (EnumInJson)1
            };
            return Ok($"The status is {enumInJson.Status}, {result.Status}");
        }
    }
}
