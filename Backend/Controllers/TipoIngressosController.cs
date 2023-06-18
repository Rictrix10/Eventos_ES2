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
    
    public class TipoIngressosController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public TipoIngressosController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<TipoIngressoViewModel[]>> GetTipoIngresso()
        {
            if (_context.TipoIngressos == null)
            {
                return NotFound();
            }

            var tipoingressos = await _context
                .TipoIngressos
                .Include(e => e.IdTipoIngresso)
                .ToListAsync();
                
            return tipoingressos
                .Select(a => new TipoIngressoViewModel() 
                {   
                    //Organizador = a.IdOrganizador
                    IdTipoIngresso = a.IdTipoIngresso,    
                    Nome = a.Nome,
                    Preco = a.Preco

                    /*
                    NomeOrganizador = new {
                        Nome = a.IdOrganizadorNavigation!.Nome ?? "sem organizador",
                        
                        Email = a.IdOrganizadorNavigation!.Email ?? "sem organizador"

                    }*/
                }).ToArray();
            
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIngresso>> GetTipoIngresso(int id)
        {
            if (_context.TipoIngressos == null)
            {
                return NotFound();
            }

            var tipoingresso = await _context.TipoIngressos.FindAsync(id);

            if (tipoingresso == null)
            {
                return NotFound();
            }

            return tipoingresso;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIngresso(int id, TipoIngresso tipoingresso)
        {
            if (id != tipoingresso.IdTipoIngresso)
            {
                return BadRequest();
            }

            _context.Entry(tipoingresso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIngressoExists(id))
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
        public async Task<ActionResult<TipoIngresso>> PostTipoIngresso(TipoIngresso tipoingresso)
        {
            if (_context.TipoIngressos == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.TipoIngressos.Add(tipoingresso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoIngresso", new { id = tipoingresso.IdTipoIngresso }, tipoingresso);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoIngresso(int id)
        {
            if (_context.TipoIngressos == null)
            {
                return NotFound();
            }

            var tipoingresso = await _context.TipoIngressos.FindAsync(id);
            if (tipoingresso == null)
            {
                return NotFound();
            }

            _context.TipoIngressos.Remove(tipoingresso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoIngressoExists(int id)
        {
            return (_context.TipoIngressos?.Any(e => e.IdTipoIngresso == id)).GetValueOrDefault();
        }
    }
    
}