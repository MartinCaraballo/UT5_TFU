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
    [Route("eventos")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly EventoService _eventoService;

        public EventoController(DataContext context, EventoService eventoService)
        {
            _context = context;
            _eventoService = eventoService;
        }

        [HttpPost]
        public IActionResult Create(Evento model)
        {
            if (model == null)
            {
                return BadRequest("Modalidad model is null.");
            }

            _eventoService.InitializeEvento(model);

            _context.Eventos.Add(model);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var eventos = _context.Eventos
                .Include(e => e.Puntuaciones)
                        .ThenInclude(p => p.Atletaa)
                .ToList();

            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.Eventos
                .Include(e => e.Puntuaciones)
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
