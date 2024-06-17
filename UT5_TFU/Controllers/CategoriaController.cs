using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class categoriaController : Controller
    { 
        private readonly CategoriaRepository _categoriaRepository;

        public categoriaController(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Categoria>))]
        public IActionResult Getcategorias()
        {
            var categorias = _categoriaRepository.GetCategorias();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categorias);
        }

        [HttpGet("/{idcategoria}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        public IActionResult Getcategoria(int idcategoria)
        {
            var categoria = _categoriaRepository.GetCategoria(idcategoria);

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