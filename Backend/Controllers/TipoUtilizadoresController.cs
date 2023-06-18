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
    
    public class TipoUtilizadoresController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public TipoUtilizadoresController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<TipoUtilizadorViewModel[]>> GetTipoUtilizador()
        {
            if (_context.TipoUtilizadors == null)
            {
                return NotFound();
            }

            var tipoutilizadores = await _context
                .TipoUtilizadors
                .Include(e => e.Utilizadors)
                .Include(e => e.IdTipoUtilizador)
                .ToListAsync();
                
            return tipoutilizadores
                .Select(tipoutilizador => new TipoUtilizadorViewModel()
                {
                    Utilizadors = tipoutilizador.Utilizadors,
                    IdTipoUtilizador = tipoutilizador.IdTipoUtilizador,
                    Tipo = tipoutilizador.Tipo
                })
                .ToArray();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUtilizador>> GetTipoUtilizador(int id)
        {
            if (_context.TipoUtilizadors == null)
            {
                return NotFound();
            }

            var tipoutilizador = await _context.TipoUtilizadors.FindAsync(id);

            if (tipoutilizador == null)
            {
                return NotFound();
            }

            return tipoutilizador;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoUtilizador(int id, TipoUtilizador tipoutilizador)
        {
            if (id != tipoutilizador.IdTipoUtilizador)
            {
                return BadRequest();
            }

            _context.Entry(tipoutilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUtilizadorExists(id))
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
        public async Task<ActionResult<TipoUtilizador>> PostUtilizador(TipoUtilizador tipoutilizador)
        {
            if (_context.TipoUtilizadors == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.TipoUtilizadors.Add(tipoutilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoUtilizador", new { id = tipoutilizador.IdTipoUtilizador }, tipoutilizador);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoUtilizador(int id)
        {
            if (_context.TipoUtilizadors == null)
            {
                return NotFound();
            }

            var tipoutilizador = await _context.TipoUtilizadors.FindAsync(id);
            if (tipoutilizador == null)
            {
                return NotFound();
            }

            _context.TipoUtilizadors.Remove(tipoutilizador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoUtilizadorExists(int id)
        {
            return (_context.TipoUtilizadors?.Any(e => e.IdTipoUtilizador == id)).GetValueOrDefault();
        }
    }
    
}