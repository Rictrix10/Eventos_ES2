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
    
    public class MensagensController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public MensagensController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<MensagemViewModel[]>> GetMensagem()
        {
            if (_context.Mensagems == null)
            {
                return NotFound();
            }

            var mensagens = await _context
                .Mensagems
                .Include(e => e.IdEventoNavigation)
                .Include(e => e.IdOrganizadorNavigation)
                .Include(e => e.IdParticipanteNavigation)
                .ToListAsync();
                
            return mensagens
                .Select(a => new MensagemViewModel() 
                {   
                    //Organizador = a.IdOrganizador
                    Mensagem1 = a.Mensagem1,
                    IdMensagem = a.IdMensagem,
                    IdEvento = a.IdEvento,
                    IdEventoNavigation = a.IdEventoNavigation,
                    IdOrganizador = a.IdOrganizador,
                    IdParticipante = a.IdParticipante,
                    IdOrganizadorNavigation = a.IdOrganizadorNavigation,
                    IdParticipanteNavigation = a.IdParticipanteNavigation
                }).ToArray();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(int id)
        {
            if (_context.Mensagems == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagems.FindAsync(id);

            if (mensagem == null)
            {
                return NotFound();
            }

            return mensagem;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMensagem(int id, Mensagem mensagem)
        {
            if (id != mensagem.IdMensagem)
            {
                return BadRequest();
            }

            _context.Entry(mensagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemExists(id))
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
        public async Task<ActionResult<Mensagem>> PostMensagem(Mensagem mensagem)
        {
            if (_context.Mensagems == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.Mensagems.Add(mensagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMensagem", new { id = mensagem.IdMensagem }, mensagem);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensagem(int id)
        {
            if (_context.Mensagems == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagems.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            _context.Mensagems.Remove(mensagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MensagemExists(int id)
        {
            return (_context.Mensagems?.Any(e => e.IdMensagem == id)).GetValueOrDefault();
        }
    }
    
}