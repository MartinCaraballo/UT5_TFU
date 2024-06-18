using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("modalidades")]
    [ApiController]
    public class ModalidadController : Controller
    { 
        private readonly ModalidadRepository _modalidadRepository;

        public ModalidadController(ModalidadRepository modalidadRepository)
        {
            _modalidadRepository = modalidadRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Modalidad>))]
        public IActionResult Getmodalidades()
        {
            var modalidades = _modalidadRepository.GetModalidades();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(modalidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Modalidad))]
        public IActionResult Getmodalidad(int id)
        {
            var modalidad = _modalidadRepository.GetModalidad(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(modalidad);
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Modalidad modalidad)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_modalidadRepository.CreateModalidad(modalidad))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}