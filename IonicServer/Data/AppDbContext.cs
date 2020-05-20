using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Skoll.Entities;
using Core.Entities;
using IonicServer.Entities;

namespace Skoll.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option)
          : base(option)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Setor> Setor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>(ConfigureUsuario);
            builder.Entity<Setor>(ConfigureSetor);
        }

        private void ConfigureUsuario(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Situacao).IsRequired();
        }
        private void ConfigureSetor(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("Setor");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Situacao).IsRequired();
        }
         private void ConfigureItem(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Setor).IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Situacao).IsRequired();
        }

    }
}
