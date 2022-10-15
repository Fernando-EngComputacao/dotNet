using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        [Range(1,600)]
        public int Duracao { get; set; }

    }
}
