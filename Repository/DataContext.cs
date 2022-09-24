using Microsoft.EntityFrameworkCore;
using Medical_Center_API_CSharp.model;

namespace Medical_Center_API_CSharp.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TipoConsulta> TipoConsulta { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
    }
}