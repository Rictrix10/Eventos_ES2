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
    
    public class InscricaoEventosController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public InscricaoEventosController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<InscricaoEventoViewModel[]>> GetInscricaoEvento()
        {
            if (_context.InscricaoEventos == null)
            {
                return NotFound();
            }

            var inscricaoeventos = await _context
                .InscricaoEventos
                .Include(e => e.IdEventoNavigation)
                .Include(e => e.IdParticipanteNavigation)
                .ToListAsync();
                
            return inscricaoeventos
                .Select(a => new InscricaoEventoViewModel() 
                {   
                    //Organizador = a.IdOrganizador
                        
                    IdInscricaoEvento = a.IdInscricaoEvento,
                    TipoIngresso = a.TipoIngresso,
                    IdEvento = a.IdEvento,
                    IdParticipante = a.IdParticipante,
                    IdEventoNavigation = a.IdEventoNavigation?.Nome,
                    IdParticipanteNavigation = a.IdParticipanteNavigation?.Nome,
                    IdParticipanteNavigationUsername = a.IdParticipanteNavigation?.Username,
                    IdParticipanteNavigationEmail = a.IdParticipanteNavigation?.Email,
                    IdParticipanteNavigationTelefone = a.IdParticipanteNavigation?.Telefone
                    /*
                    NomeOrganizador = new {
                        Nome = a.IdOrganizadorNavigation!.Nome ?? "sem organizador",
                        
                        Email = a.IdOrganizadorNavigation!.Email ?? "sem organizador"

                    }*/
                }).ToArray();
            
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoEvento>> GetInscricaoEvento(int id)
        {
            if (_context.InscricaoEventos == null)
            {
                return NotFound();
            }

            var inscricaoevento = await _context.InscricaoEventos.FindAsync(id);

            if (inscricaoevento == null)
            {
                return NotFound();
            }

            return inscricaoevento;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricaoEvento(int id, InscricaoEvento inscricaoevento)
        {
            if (id != inscricaoevento.IdEvento)
            {
                return BadRequest();
            }

            _context.Entry(inscricaoevento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoEventoExists(id))
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
        public async Task<ActionResult<InscricaoEvento>> PostInscricaoEvento(InscricaoEvento inscricaoevento)
        {
            if (_context.InscricaoEventos == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.InscricaoEventos.Add(inscricaoevento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricaoEvento", new { id = inscricaoevento.IdEvento });
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricaoEvento(int id)
        {
            if (_context.InscricaoEventos == null)
            {
                return NotFound();
            }

            var inscricaoevento = await _context.InscricaoEventos.FindAsync(id);
            if (inscricaoevento == null)
            {
                return NotFound();
            }

            _context.InscricaoEventos.Remove(inscricaoevento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscricaoEventoExists(int id)
        {
            return (_context.InscricaoEventos?.Any(e => e.IdInscricaoEvento == id)).GetValueOrDefault();
        }
    }
    
}