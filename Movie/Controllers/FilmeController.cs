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
        private static int id = 1;

        [HttpPost]
        public Filme AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            return filme;
        }

        [HttpGet]
        public IEnumerable<Filme> BuscarTodosOsFilmes()
        {
            return filmes;
        }

        [HttpGet("{id}")]
        public Filme BuscarFilmePorId(int id)
        {
            foreach(Filme filme in filmes){
                if (filme.Id == id)
                    return filme;
            }
            return null;
        }
    }
}
