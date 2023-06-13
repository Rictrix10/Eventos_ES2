using BusinessLogic.Context;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/utilizadores")]
    public class UtilizadorController : ControllerBase
    {
        private readonly EventosDBContext _dbContext;

        public UtilizadorController(EventosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizador>>> GetUtilizadores()
        {
            var utilizadores = await _dbContext.Utilizadors.ToListAsync();
            return Ok(utilizadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetUtilizador(int id)
        {
            var utilizador = await _dbContext.Utilizadors.FindAsync(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            return Ok(utilizador);
        }

        [HttpPost]
        public async Task<ActionResult<Utilizador>> CreateUtilizador(Utilizador utilizador)
        {
            _dbContext.Utilizadors.Add(utilizador);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUtilizador), new { id = utilizador.IdUtilizador }, utilizador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUtilizador(int id, Utilizador utilizador)
        {
            if (id != utilizador.IdUtilizador)
            {
                return BadRequest();
            }

            _dbContext.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizador(int id)
        {
            var utilizador = await _dbContext.Utilizadors.FindAsync(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            _dbContext.Utilizadors.Remove(utilizador);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilizadorExists(int id)
        {
            return _dbContext.Utilizadors.Any(u => u.IdUtilizador == id);
        }
    }
}
