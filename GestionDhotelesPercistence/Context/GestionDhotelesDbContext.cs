using Microsoft.EntityFrameworkCore;
using GestionDhoteles.Domain.Entities;
using GestionDhotelesPercistence.Interfaces;

namespace GestionDhotelesPercistence.Context
{
    public class GestionDhotelesDbContext : DbContext
    {
        public GestionDhotelesDbContext(DbContextOptions<GestionDhotelesDbContext> options) : base(options)
        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitacion { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Piso> Piso { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Recepcion> Recepcion { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}