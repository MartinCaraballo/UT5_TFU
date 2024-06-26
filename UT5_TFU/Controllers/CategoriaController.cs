using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly CategoriaService _categoriaService;

        public CategoriaController(DataContext context, CategoriaService categoriaService)
        {
            _context = context;
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public IActionResult Create(Categoria model)
        {
            if (model == null)
            {
                return BadRequest("Modalidad model is null.");
            }

            _categoriaService.InitializeCategoria(model);

            _context.Categorias.Add(model);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categorias = _context.Categorias
                .Include(c => c.Eventos)
                        .ThenInclude(e => e.Puntuaciones)
                            .ThenInclude(p => p.Atletaa)
                .ToList();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.Categorias
                    .Include(c => c.Eventos)
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
