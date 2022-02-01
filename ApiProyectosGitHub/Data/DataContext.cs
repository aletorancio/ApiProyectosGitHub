using ApiProyectosGitHub.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiProyectosGitHub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<InfoProyecto> InfoProyectos { get; set; }
    }
}
