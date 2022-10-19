using System.ComponentModel.DataAnnotations;

namespace Movie.Controllers.dto
{
    public class FilmeFormulario
    {
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        [Range(1, 600)]
        public int Duracao { get; set; }
    }
}
