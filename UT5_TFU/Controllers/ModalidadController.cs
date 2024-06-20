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
    [Route("modalidades")]
    public class ModalidadController : ControllerBase
    {
        private readonly DataContext _context;

        public ModalidadController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Modalidad model)
        {
            if (model == null)
            {
                return BadRequest("Modalidad model is null.");
            }

            if (model.Categorias == null)
            {
                model.Categorias = new List<Categoria>();
            }

            foreach (var categoria in model.Categorias)
            {
                if (categoria.Eventos == null)
                {
                    categoria.Eventos = new List<Evento>();
                }

                foreach (var evento in categoria.Eventos)
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
            }

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
