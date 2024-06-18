using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("eventos")]
    [ApiController]
    public class EventoController : Controller
    { 
        private readonly EventoRepository _eventoRepository;

        public EventoController(EventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Evento>))]
        public IActionResult GetEventos()
        {
            var eventos = _eventoRepository.GetEventos();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(eventos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Evento))]
        public IActionResult GetEvento(int id)
        {
            var evento = _eventoRepository.GetEvento(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(evento);
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_eventoRepository.CreateEvento(evento))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}