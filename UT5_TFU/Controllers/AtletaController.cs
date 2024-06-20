using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("atletas")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly AtletaService _atletaService;

        public AtletaController(AtletaService atletaService)
        {
            _atletaService = atletaService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Atleta>))]
        public IActionResult GetAtletas()
        {
            var atletas = _atletaService.GetAtletas();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(atletas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Atleta))]
        [ProducesResponseType(404)]
        public IActionResult GetAtleta(int id)
        {
            var atleta = _atletaService.GetAtleta(id);

            if (atleta == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(atleta);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateAtleta([FromBody] Atleta atleta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_atletaService.CreateAtleta(atleta))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
