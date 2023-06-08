using ApiConciertosMysqlExamen.Data;
using ApiConciertosMysqlExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiConciertosMysqlExamen.Repositories
{
    public class RepositoryConciertos
    {
        private ConciertoContext context;

        public RepositoryConciertos(ConciertoContext context)
        {
            this.context = context;
        }

        public async Task<List<CategoriaEvento>> GetCategoriasAsync()
        {
            return await this.context.CategoriaEventos.ToListAsync();
        }

        public async Task<List<Eventos>> GetEventosAsync()
        {
            return await this.context.Eventos.ToListAsync();
        }

        public async Task<List<Eventos>> FindEventosPorCategoriaAsync(int id)
        {
            return await this.context.Eventos
                .Where(x => x.IdCategoria == id)
                .ToListAsync();
        }

        private async Task<int> GetMaxIdEventoAsync()
        {
            return await this.context.Eventos.MaxAsync(x => x.IdEvento) + 1;
        }

        public async Task CreateEventoAsync(string nombre, string artista,int idcategoria, string imagen)
        {
            Eventos evento = new Eventos
            {
                IdEvento = await this.GetMaxIdEventoAsync(),
                Nombre = nombre,
                Artista = artista,
                IdCategoria = idcategoria,  
                Imagen = imagen
            };
            this.context.Eventos.Add(evento);
            await this.context.SaveChangesAsync();
        }
    }
}
