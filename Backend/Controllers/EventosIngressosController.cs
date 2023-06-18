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
    
    public class EventosIngressosController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public EventosIngressosController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<EventoIngressoViewModel[]>> GetEventoIngresso()
        {
            if (_context.EventoIngressos == null)
            {
                return NotFound();
            }

            var eventsingresso = await _context.
                EventoIngressos.ToListAsync();
                
                
            return eventsingresso
                .Select(a => new EventoIngressoViewModel() 
                {   
                    IdIngresso = a.IdIngresso,
                    Tipo_Ingresso = a.TipoIngresso,
                    Quantidade = a.Quantidade,
                    Preco = a.Preco,
                    IdEvento = a.IdEvento
                    
                }).ToArray();
            
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoIngresso>> GetEventoIngresso(int id)
        {
            if (_context.EventoIngressos == null)
            {
                return NotFound();
            }

            var eventoingresso = await _context.EventoIngressos.FindAsync(id);

            if (eventoingresso == null)
            {
                return NotFound();
            }

            return eventoingresso;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoIngresso(int id, EventoIngresso eventoingresso)
        {
            if (id != eventoingresso.IdIngresso)
            {
                return BadRequest();
            }

            _context.Entry(eventoingresso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoIngressoExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] EventoIngresso eventoIngresso)
        {
            if (ModelState.IsValid)
            {
                var ingresso = new EventoIngresso()
                {
                    IdIngresso = eventoIngresso.IdIngresso,
                    TipoIngresso = eventoIngresso.TipoIngresso,
                    Quantidade = eventoIngresso.Quantidade,
                    Preco = eventoIngresso.Preco,
                    IdEvento = eventoIngresso.IdEvento

                };

                _context.EventoIngressos.Add(ingresso);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetEventoIngresso), new { id = ingresso.IdIngresso }, ingresso);
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoIngresso(int id)
        {
            if (_context.EventoIngressos == null)
            {
                return NotFound();
            }

            var eventoingresso = await _context.EventoIngressos.FindAsync(id);
            if (eventoingresso == null)
            {
                return NotFound();
            }

            _context.EventoIngressos.Remove(eventoingresso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoIngressoExists(int id)
        {
            return (_context.EventoIngressos?.Any(e => e.IdIngresso == id)).GetValueOrDefault();
        }
    }
    
}
