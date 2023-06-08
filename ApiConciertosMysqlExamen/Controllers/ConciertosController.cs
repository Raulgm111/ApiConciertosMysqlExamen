using ApiConciertosMysqlExamen.Models;
using ApiConciertosMysqlExamen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertosMysqlExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConciertosController : ControllerBase
    {
        private RepositoryConciertos repo;

        public ConciertosController(RepositoryConciertos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<CategoriaEvento>> GetCategorias()
        {
            return await this.repo.GetCategoriasAsync();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<Eventos>> GetEventos()
        {
            return await this.repo.GetEventosAsync();
        }

        [HttpGet("{id}")]
        public async Task<List<Eventos>> FindEventoPorCategoria(int id)
        {
            return await this.repo.FindEventosPorCategoriaAsync(id);
        }

        [HttpPost]
        public async Task CreateEvento(Eventos evento)
        {
            await this.repo.CreateEventoAsync(evento.Nombre,evento.Artista,evento.IdCategoria,evento.Imagen);
        }
    }
}
