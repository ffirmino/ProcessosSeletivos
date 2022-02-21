using Microsoft.EntityFrameworkCore;

namespace Webmotors.Infra.DBContext
{
    public partial class DbContextWebmotors : DbContext
    {
        public DbContextWebmotors()
        {
        }

        public DbContextWebmotors(DbContextOptions<DbContextWebmotors> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAnuncioWebmotors> TbAnuncioWebmotors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAnuncioWebmotors>(entity =>
            {
                if (Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
                {
                    entity.HasNoKey();
                    entity.Ignore(e => e.Id);
                    entity.ToView("vTbAnuncioWebmotors");
                }
                else
                {
                    entity.HasKey(e => e.Id);
                }

                entity.ToTable("tb_AnuncioWebmotors");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("modelo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasColumnName("observacao")
                    .HasColumnType("text");

                entity.Property(e => e.Quilometragem).HasColumnName("quilometragem");

                entity.Property(e => e.Versao)
                    .IsRequired()
                    .HasColumnName("versao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
