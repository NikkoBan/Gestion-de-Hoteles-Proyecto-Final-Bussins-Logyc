using GestionDhoteles.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionDhoteles.Infrastructure.Context
{
    public class GestionDhotelesContext : DbContext
    {
        public GestionDhotelesContext(DbContextOptions<GestionDhotelesContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitaciones { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Piso> Pisos { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasOne(c => c.Servicio).WithMany(s => s.Categorias).HasForeignKey(c => c.IdServicio);
            modelBuilder.Entity<Recepcion>().HasOne(r => r.Cliente).WithMany(c => c.Recepciones).HasForeignKey(r => r.IdCliente);
            modelBuilder.Entity<Recepcion>().HasOne(r => r.Habitacion).WithMany().HasForeignKey(r => r.IdHabitacion);
            modelBuilder.Entity<Usuario>().HasOne(u => u.RolUsuario).WithMany(r => r.Usuarios).HasForeignKey(u => u.IdRolUsuario);
        }
    }
}