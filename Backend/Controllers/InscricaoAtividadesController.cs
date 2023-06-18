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
    
    public class InscricaoAtividadesController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public InscricaoAtividadesController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<InscricaoAtividadeViewModel[]>> GetUtilizador()
        {
            if (_context.InscricaoAtividades == null)
            {
                return NotFound();
            }

            var inscricaoatividades = await _context
                .InscricaoAtividades
                .ToListAsync();
                
            return inscricaoatividades
                .Select(a => new InscricaoAtividadeViewModel() 
                {   
                    IdInscricaoAtividade = a.IdInscricaoAtividade,
                    IdParticipante = a.IdParticipante,
                    IdAtividade = a.IdAtividade
                }).ToArray();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoAtividade>> GetInscricaoAtividade(int id)
        {
            if (_context.InscricaoAtividades == null)
            {
                return NotFound();
            }

            var InscricaoAtividade = await _context.InscricaoAtividades.FindAsync(id);

            if (InscricaoAtividade == null)
            {
                return NotFound();
            }

            return InscricaoAtividade;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizador(int id, InscricaoAtividade inscricaoatividade)
        {
            if (id != inscricaoatividade.IdAtividade)
            {
                return BadRequest();
            }

            _context.Entry(inscricaoatividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoAtividadeExists(id))
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

        private bool InscricaoAtividadesExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilizador>> PostInscricaoAtividade(InscricaoAtividade inscricaoatividade)
        {
            if (_context.InscricaoAtividades == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.InscricaoAtividades.Add(inscricaoatividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizador", new { id = inscricaoatividade.IdAtividade });
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricaoAtividade(int id)
        {
            if (_context.InscricaoAtividades == null)
            {
                return NotFound();
            }

            var utilizador = await _context.InscricaoAtividades.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _context.InscricaoAtividades.Remove(utilizador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscricaoAtividadeExists(int id)
        {
            return (_context.InscricaoAtividades?.Any(e => e.IdAtividade == id)).GetValueOrDefault();
        }
    }
    
}
