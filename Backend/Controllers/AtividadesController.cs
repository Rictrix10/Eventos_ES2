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

    public class AtividadesController : ControllerBase
    {

        private readonly EventosDBContext _context;

        public AtividadesController(EventosDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<AtividadeViewModel[]>> GetAtividade()
        {
            if (_context.Atividades == null)
            {
                return NotFound();
            }

            var atividades = await _context
                .Atividades
                .Include(e => e.IdEventoNavigation)
                .ToListAsync();

            return atividades
                .Select(a => new AtividadeViewModel()
                {
                    //Organizador = a.IdOrganizador
                    IdAtividade = a.IdAtividade,
                    Nome = a.Nome,
                    Data = a.Data,
                    Hora = a.Hora,
                    Descricao = a.Descricao,
                    IdEvento = a.IdEvento,
                    EventoData = a.IdEventoNavigation?.Data,
                    EventoHora = a.IdEventoNavigation?.Hora

                    /*
                    NomeOrganizador = new {
                        Nome = a.IdOrganizadorNavigation!.Nome ?? "sem organizador",
                        
                        Email = a.IdOrganizadorNavigation!.Email ?? "sem organizador"

                    }*/
                }).ToArray();

        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetAtividade(int id)
        {
            if (_context.Atividades == null)
            {
                return NotFound();
            }

            var atividade = await _context.Utilizadors.FindAsync(id);

            if (atividade == null)
            {
                return NotFound();
            }

            return atividade;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividade(int id, Atividade atividade)
        {
            if (id != atividade.IdAtividade)
            {
                return BadRequest();
            }

            _context.Entry(atividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
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
        public async Task<ActionResult<Atividade>> PostUtilizador(Atividade atividade)
        {
            if (_context.Atividades == null)
            {
                return Problem("Entity set 'ES2DbContext.Authors'  is null.");
            }

            _context.Atividades.Add(atividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtividade", new { id = atividade.IdAtividade }, atividade);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtividade(int id)
        {
            if (_context.Atividades == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtividadeExists(int id)
        {
            return (_context.Atividades?.Any(e => e.IdAtividade == id)).GetValueOrDefault();
        }
    }

}