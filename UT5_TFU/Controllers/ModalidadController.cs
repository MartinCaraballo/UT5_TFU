using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Data;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("modalidades")]
    public class ModalidadController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ModalidadService _modalidadService;

        public ModalidadController(DataContext context, ModalidadService modalidadService)
        {
            _context = context;
            _modalidadService = modalidadService;
        }

        [HttpPost]
        public IActionResult Create(Modalidad model)
        {
            if (model == null)
            {
                return BadRequest("Modalidad model is null.");
            }

            _modalidadService.InitializeModalidad(model);

            _context.Modalidades.Add(model);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var modalidades = _context.Modalidades
                .Include(m => m.Categorias)
                    .ThenInclude(c => c.Eventos)
                        .ThenInclude(e => e.Puntuaciones)
                            .ThenInclude(p => p.Atletaa)
                .ToList();

            return Ok(modalidades);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.Modalidades
                .Include(m => m.Categorias)
                    .ThenInclude(c => c.Eventos)
                        .ThenInclude(e => e.Puntuaciones)
                            .ThenInclude(p => p.Atletaa)
                .FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
