using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("atletas")]
    [ApiController]
    public class AtletaController : Controller
    { 
        private readonly AtletaRepository _atletaRepository;

        public AtletaController(AtletaRepository atletaRepository)
        {
            _atletaRepository = atletaRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Atleta>))]
        public IActionResult GetAtletas()
        {
            var atletas = _atletaRepository.GetAtletas();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(atletas);
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(200, Type = typeof(Atleta))]
        public IActionResult GetAtleta(int idAtleta)
        {
            var atleta = _atletaRepository.GetAtleta(idAtleta);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(atleta);
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Atleta atleta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_atletaRepository.CreateAtleta(atleta))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}