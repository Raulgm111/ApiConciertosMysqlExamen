using ApiConciertosMysqlExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiConciertosMysqlExamen.Data
{
    public class ConciertoContext:DbContext
    {
        public ConciertoContext(DbContextOptions<ConciertoContext> options)
            : base(options) { }
        public DbSet<CategoriaEvento> CategoriaEventos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
    }
}
