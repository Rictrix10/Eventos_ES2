using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Context;
using BusinessLogic.Models;
using System.Collections.Generic;

namespace Frontend.Pages
{
    public class EventosModel : PageModel
    {
        private readonly EventosDBContext _context;

        public EventosModel()
        {
            _context = new EventosDBContext();
        }

        public List<EventoViewModel> Evento { get; set; } = new List<EventoViewModel>();

        public async Task OnGetAsync()
        {
            if (_context.Eventos != null)
            {
                Evento = await _context.Eventos
                    .Select(e => new EventoViewModel(e))
                    .ToListAsync();
            }
        }
    }
}
