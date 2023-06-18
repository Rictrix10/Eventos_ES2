using BusinessLogic.Entities;

namespace BusinessLogic.Models
{
    public class TipoIngressoViewModel
    {
        public TipoIngressoViewModel()
        {

        }

        public TipoIngressoViewModel(TipoIngresso tipoingresso)
        {   
            IdTipoIngresso = tipoingresso.IdTipoIngresso;
            Nome = tipoingresso.Nome;
            Preco = tipoingresso.Preco;
            
            
        }

        public int IdTipoIngresso { get; set; }
        
        public string? Nome { get; set; }

        public decimal? Preco { get; set; }
        
    }
}