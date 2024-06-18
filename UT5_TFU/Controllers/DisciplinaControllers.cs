using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("disciplinas")]
    [ApiController]
    public class DisciplinaController : Controller
    { 
        private readonly DisciplinaRepository _disciplinaRepository;

        public DisciplinaController(DisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Disciplina>))]
        public IActionResult GetDisciplinas()
        {
            var disciplinas = _disciplinaRepository.GetDisciplinas();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(disciplinas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Disciplina))]
        public IActionResult GetDisciplina(int id)
        {
            var disciplina = _disciplinaRepository.GetDisciplina(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(disciplina);
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Disciplina disciplina)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_disciplinaRepository.CreateDisciplina(disciplina))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}