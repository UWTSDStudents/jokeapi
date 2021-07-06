using System;
using System.Collections.Generic;
//using System.Net.Mime;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;	// StatusCodes
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using jokeapi.models;
using jokeapilib;

namespace jokeapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeAPIController : ControllerBase
    {
        private readonly ILogger<JokeAPIController> _logger;
		private IJokeAPI _service;

        public JokeAPIController(ILogger<JokeAPIController> logger, IJokeAPI service)
        {
            _logger = logger;
			_service = service;
        }

        [HttpGet("/api/joke")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<JokeEntry>> Get()
        {
            return _service.GetJokes();
        }
		
		[HttpGet("/api/joke/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JokeEntry> GetJoke(string id)
        {
            JokeEntry joke = _service.GetJoke(id);
			if(joke == null) return NotFound(); // Status code 404
			return joke;
			
			// return BadRequest() ///400
			// return NotFound() // 404
			// 
        }
		
		[HttpGet("/api/joke/next")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JokeEntry> GetNextJoke()
        {
            JokeEntry joke = _service.Next();
			if(joke == null) return NotFound(); // Status code 404
			return joke;
        }
		
		[HttpPost("/api/joke")]
		[ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Add(Joke joke)
        {
			string id = _service.Add(joke);
			
			// Return status code 201 and HTTP
			// header location=http://localhost:5000/api/joke?id=thejokeid
			return CreatedAtAction(nameof(Add),
				new { id = id }, 
				joke);
        }
		
		[HttpDelete("/api/joke")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Remove(string id)
        {
            if(_service.Remove(id)) return Ok(); // Status code 200
			else return NotFound(); // Status code 404		
        }
		
		[HttpPut("/api/joke")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult Edit(string id, Joke newJoke)
		{
			if(_service.Edit(id, newJoke)) return Ok(); // Status code 200
			else return NotFound(); // Status code 404	
		}
		
		
		[HttpGet("/api/joke/reset")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public void Reset()
		{
			_service.Reset();
			//return StatusCode(200);  // The WebAPI will auto return status 200
		}
    }
}
