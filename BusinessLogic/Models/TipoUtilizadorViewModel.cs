using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class TipoUtilizadorViewModel
    {
        public TipoUtilizadorViewModel()
        {

        }

        public TipoUtilizadorViewModel(TipoUtilizador tipoutilizador)
        {
            IdTipoUtilizador = tipoutilizador.IdTipoUtilizador;
            Tipo = tipoutilizador.Tipo;
        }

        public string? Tipo { get; set; }

        public int IdTipoUtilizador { get; set; }
        
    }
}