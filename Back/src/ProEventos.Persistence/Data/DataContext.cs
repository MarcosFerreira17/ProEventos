using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Data
{
    public class ProEventosContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }


    }
}