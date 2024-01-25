using BussinesLayer.DTO;
using BussinesLayer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {

        private readonly IAlgorithmService _algorithmService;

        public SolutionController(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        // GET: api/<SolutionController>
        [HttpGet("string-splitting")]
        public IActionResult GetSolution_1([FromBody] RequestSolution request)
        {
            try
            {
                var result = _algorithmService.StringSplitting(request);
                return Ok(result.Result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/<SolutionController>
        [HttpGet("odd-calculator")]
        public IActionResult GetSolution_2([FromBody] RequestSolution request)
        {
            try
            {
                var result = _algorithmService.oddCalculator(request);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/<SolutionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SolutionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SolutionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SolutionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SolutionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
