using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
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
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(BuscarFilmePorId), new {Id = filme.Id},filme);
        }

        [HttpGet]
        //public IEnumerable<Filme> BuscarTodosOsFilmes()
        public IActionResult BuscarTodosOsFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            return (filme != null ? Ok(filme) : NotFound());
        }
    }
}
