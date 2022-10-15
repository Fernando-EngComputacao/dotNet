using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using System.Reflection.Metadata.Ecma335;

namespace Movie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public Filme AdicionaFilme([FromBody] Filme filme)
        {
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            return filme;
        }

        [HttpGet]
        public List<Filme> RecuperarFilmes()
        {
            return filmes;
        }
    }
}
