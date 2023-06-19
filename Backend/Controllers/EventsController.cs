using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Context;
using BusinessLogic.Entities;
using BusinessLogic.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EventsController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public EventsController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<EventoViewModel[]>> GetEvento()
        {
            if (_context.Eventos == null)
            {
                return NotFound();
            }

            var events = await _context
                .Eventos.Include(e => e.IdOrganizadorNavigation).ToListAsync();
                
            return events
                .Select(a => new EventoViewModel() 
                {   
                    //Organizador = a.IdOrganizador
                    IdEvento = a.IdEvento,    
                    Nome = a.Nome,
                    Data = a.Data,
                    Hora = a.Hora,
                    Local = a.Local,
                    Descricao = a.Descricao,
                    Capacidademax = a.Capacidademax,
                    Categoria = a.Categoria,
                    IdOrganizador = a.IdOrganizador,
                    NomeOrganizador = a.IdOrganizadorNavigation?.Nome
                    
                    /*
                    NomeOrganizador = new {
                        Nome = a.IdOrganizadorNavigation!.Nome ?? "sem organizador",
                        
                        Email = a.IdOrganizadorNavigation!.Email ?? "sem organizador"

                    }*/
                }).ToArray();
            
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            if (_context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.IdEvento)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evento evento)
        {
            if (ModelState.IsValid)
            {
                var addevento = new Evento()
                {
                    IdEvento = evento.IdEvento,
                    Nome = evento.Nome,
                    Data = evento.Data,
                    Hora = evento.Hora,
                    Local = evento.Local,
                    Descricao = evento.Descricao,
                    Capacidademax = evento.Capacidademax,
                    Categoria = evento.Categoria,
                    IdOrganizador = evento.IdOrganizador
                    
                };

                _context.Eventos.Add(addevento);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetEvento), new { id = addevento.IdEvento }, addevento);
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            if (_context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return (_context.Eventos?.Any(e => e.IdEvento == id)).GetValueOrDefault();
        }
    }
    
}
