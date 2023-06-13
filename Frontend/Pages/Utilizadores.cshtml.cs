using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Context;
using BusinessLogic.Models;
namespace Frontend.Pages
{
    public class UtilizadoresModel : PageModel
    {
        private readonly EventosDBContext  _context;
        public UtilizadoresModel()
        {
            _context = new EventosDBContext();
        }
        public List<UtilizadorViewModel> Utilizador { get;set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Utilizadors != null)
            {
                Utilizador = await _context.Utilizadors
                    .Include(m => m.IdUtilizador)
                    .Select(m => new UtilizadorViewModel(m)).ToListAsync();
            }
        }
    }


}