using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Repository;
using WebApp.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Categoria model)
        {
            if (model == null)
            {
                return BadRequest("Modalidad model is null.");
            }

            if (model.Eventos == null)
            {
                model.Eventos = new List<Evento>();
            }

            foreach (var evento in model.Eventos)
            {
                if (evento.Puntuaciones == null)
                {
                    evento.Puntuaciones = new List<Puntuacion>();
                }

                foreach (var puntuacion in evento.Puntuaciones)
                {
                    if (puntuacion.Atletaa == null)
                    {
                        puntuacion.Atletaa = new Atleta();
                    }
                }
            }

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
