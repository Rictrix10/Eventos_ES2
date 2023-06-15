using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Context;
using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend.Pages
{
    public class EventosModel : PageModel
    {
        private readonly EventosDBContext _context;

        public EventosModel(EventosDBContext context)
        {
            _context = context;
        }

        public List<EventoViewModel> Evento { get; set; } = new List<EventoViewModel>();

        public async Task OnGetAsync()
        {
            Evento = await _context.Eventos
                .Select(e => new EventoViewModel(e))
                .ToListAsync();
        }
    }
}
