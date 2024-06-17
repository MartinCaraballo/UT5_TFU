using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriaController : Controller
    { 
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaController(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Categoria>))]
        public IActionResult GetCategorias()
        {
            var categorias = _categoriaRepository.GetCategorias();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categorias);
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        public IActionResult GetCategoria(int idCategoria)
        {
            var categoria = _categoriaRepository.GetCategoria(idCategoria);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categoria);
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_categoriaRepository.CreateCategoria(categoria))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}