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
    
    public class AutenticacoesController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public AutenticacoesController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<AutenticacaoViewModel[]>> GetAutenticacao()
        {
            if (_context.Autenticacaos == null)
            {
                return NotFound();
            }

            var autenticacoes = await _context
                .Autenticacaos
                .ToListAsync();
                
            return autenticacoes
                .Select(a => new AutenticacaoViewModel() 
                {   
                    //Organizador = a.IdOrganizador
                        
                    IdAutenticacao = a.IdAutenticacao,
                    Tipo = a.Tipo,
                    Utilizadors = a.Utilizadors
                    /*
                    NomeOrganizador = new {
                        Nome = a.IdOrganizadorNavigation!.Nome ?? "sem organizador",
                        
                        Email = a.IdOrganizadorNavigation!.Email ?? "sem organizador"

                    }*/
                }).ToArray();
            
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autenticacao>> GetAutenticacao(int id)
        {
            if (_context.Autenticacaos == null)
            {
                return NotFound();
            }

            var autenticacao = await _context.Autenticacaos.FindAsync(id);

            if (autenticacao == null)
            {
                return NotFound();
            }

            return autenticacao;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutenticacao(int id, Autenticacao autenticacao)
        {
            if (id != autenticacao.IdAutenticacao)
            {
                return BadRequest();
            }

            _context.Entry(autenticacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutenticacaoExists(id))
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
        public async Task<ActionResult<Autenticacao>> PostAutenticacao(Autenticacao autenticacao)
        {
            if (_context.Autenticacaos == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.Autenticacaos.Add(autenticacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutenticacao", new { id = autenticacao.IdAutenticacao }, autenticacao);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutenticacao(int id)
        {
            if (_context.Autenticacaos == null)
            {
                return NotFound();
            }

            var autenticacao = await _context.Autenticacaos.FindAsync(id);
            if (autenticacao == null)
            {
                return NotFound();
            }

            _context.Autenticacaos.Remove(autenticacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutenticacaoExists(int id)
        {
            return (_context.Autenticacaos?.Any(e => e.IdAutenticacao == id)).GetValueOrDefault();
        }
    }
    
}
