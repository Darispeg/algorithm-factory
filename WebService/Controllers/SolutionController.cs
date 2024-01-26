using BussinesLayer.DTO;
using BussinesLayer.Service;
using Microsoft.AspNetCore.Mvc;
using System;

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

        // GET: api/<SolutionController>/string-splitting
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

        // GET: api/<SolutionController>/odd-calculator
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
        public IActionResult Get()
        {
            try
            {
                var result = _algorithmService.getAllSolutions();
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
