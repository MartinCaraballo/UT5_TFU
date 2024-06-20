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
    [Route("disciplinas")]
    public class DisciplinaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly DisciplinaService _disciplinaService;
        public DisciplinaController(DataContext context, DisciplinaService disciplinaService)
        {
            _context = context;
            _disciplinaService = disciplinaService;
        }

        [HttpPost]
        public IActionResult Create(Disciplina model)
        {
            if (model == null)
            {
                return BadRequest("Modalidad model is null.");
            }

            _disciplinaService.InitializeDisciplina(model);

            _context.Disciplinas.Add(model);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var disciplinas = _context.Disciplinas
                .Include(r => r.Modalidades)
                    .ThenInclude(m => m.Categorias)
                        .ThenInclude(c => c.Eventos)
                            .ThenInclude(e => e.Puntuaciones)
                                .ThenInclude(p => p.Atletaa)
                .ToList();

            return Ok(disciplinas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.Disciplinas
                .Include(r => r.Modalidades)
                    .ThenInclude(m => m.Categorias)
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
