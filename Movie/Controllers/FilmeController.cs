using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Movie.Models;
using Movie.Controllers.dto;
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
        public IActionResult AdicionaFilme([FromBody] FilmeFormulario form)
        {
            Filme filme = new Filme(form.Titulo, form.Diretor, form.Genero, form.Duracao);
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

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] FilmeFormulario form)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            filme.Titulo = form.Titulo;
            filme.Diretor = form.Diretor;
            filme.Genero = form.Genero;
            filme.Duracao = form.Duracao;
            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            filmes.Remove(filme);
            return Ok(filme);
        }
    }
}
