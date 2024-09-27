using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos2.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 100)]
        public double Preco { get; set; }
    }
}
