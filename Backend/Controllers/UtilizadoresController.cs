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
    
    public class UtilizadoresController : ControllerBase
    {
        
        private readonly  EventosDBContext _context;

        public UtilizadoresController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<UtilizadorViewModel[]>> GetUtilizador()
        {
            if (_context.Utilizadors == null)
            {
                return NotFound();
            }

            var utilizadores = await _context
                .Utilizadors
                .Include(e => e.IdTipoUtilizadorNavigation)
                .Include(e => e.IdAutenticacaoNavigation)
                .ToListAsync();
                
            return utilizadores
                .Select(a => new UtilizadorViewModel() 
                {   
                    //Organizador = a.IdOrganizador
                        
                    Username = a.Username,
                    Nome = a.Nome,
                    Email = a.Email,
                    Password = a.Password,
                    Telefone = a.Telefone,
                    Tipo = a.Tipo,
                    Autenticacao_tipo = a.Autenticacao,
                    Id_Tipo_Utilizador = a.IdTipoUtilizador,
                    Tipo_Utilizador = a.IdTipoUtilizadorNavigation?.Tipo,
                    Tipo_Autenticacao = a.IdAutenticacaoNavigation?.Tipo
                    /*
                    NomeOrganizador = new {
                        Nome = a.IdOrganizadorNavigation!.Nome ?? "sem organizador",
                        
                        Email = a.IdOrganizadorNavigation!.Email ?? "sem organizador"

                    }*/
                }).ToArray();
            
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetUtilizador(int id)
        {
            if (_context.Utilizadors == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors.FindAsync(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            return utilizador;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizador(int id, Utilizador utilizador)
        {
            if (id != utilizador.IdUtilizador)
            {
                return BadRequest();
            }

            _context.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadorExists(id))
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
        public async Task<ActionResult<Utilizador>> PostUtilizador(Utilizador utilizador)
        {
            if (_context.Utilizadors == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.Utilizadors.Add(utilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizador", new { id = utilizador.IdUtilizador }, utilizador);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizador(int id)
        {
            if (_context.Utilizadors == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _context.Utilizadors.Remove(utilizador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilizadorExists(int id)
        {
            return (_context.Utilizadors?.Any(e => e.IdUtilizador == id)).GetValueOrDefault();
        }
    }
    
}
