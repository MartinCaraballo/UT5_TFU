using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("puntuaciones")]
    public class PuntuacionController : ControllerBase
    {
        private readonly DataContext _context;

        public PuntuacionController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Puntuacion model)
        {
            if (model == null)
            {
                return BadRequest("Modalidad model is null.");
            }

            _context.Puntuaciones.Add(model);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var puntuaciones = _context.Puntuaciones
                .Include(p => p.Atletaa)
                .ToList();

            return Ok(puntuaciones);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _context.Puntuaciones
                .Include(p => p.Atletaa)
                .FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
