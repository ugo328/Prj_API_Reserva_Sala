using AgendaSalas.Models;
using Microsoft.EntityFrameworkCore;


namespace AgendaSalas.Context
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<Obgetos> Obgetos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<DisponibilidadeSala> DisponibilidadeSala { get; set; }
        public DbSet<AgendaSalas.Models.Periodo> Periodo { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
    }
}
