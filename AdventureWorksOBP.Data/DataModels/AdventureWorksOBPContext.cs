using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdventureWorksOBP.Data.Models
{
    public partial class AdventureWorksOBPContext : DbContext
    {
        public AdventureWorksOBPContext()
        {
        }

        public AdventureWorksOBPContext(DbContextOptions<AdventureWorksOBPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }
        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<Komercijalist> Komercijalisti { get; set; }
        public virtual DbSet<KreditnaKartica> KreditneKartice { get; set; }
        public virtual DbSet<Kupac> Kupci { get; set; }
        public virtual DbSet<Potkategorija> Potkategorije { get; set; }
        public virtual DbSet<Proizvod> Proizvodi { get; set; }
        public virtual DbSet<Racun> Racuni { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AdventureWorksOBP;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Drzava");

                entity.Property(e => e.Id).HasColumnName("IDDrzava");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Grad");

                entity.Property(e => e.Id).HasColumnName("IDGrad");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Gradovi)
                    .HasForeignKey(d => d.DrzavaId)
                    .HasConstraintName("FK_Grad_Drzava");
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Kategorija");

                entity.Property(e => e.Id).HasColumnName("IDKategorija");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");
            });

            modelBuilder.Entity<Komercijalist>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Komercijalist");

                entity.Property(e => e.Id).HasColumnName("IDKomercijalist");

                entity.Property(e => e.Ime)
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");
            });

            modelBuilder.Entity<KreditnaKartica>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("KreditnaKartica");

                entity.Property(e => e.Id).HasColumnName("IDKreditnaKartica");

                entity.Property(e => e.Broj)
                    .IsRequired()
                    .HasMaxLength(25)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.Tip)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Kupac");

                entity.Property(e => e.Id).HasColumnName("IDKupac");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(25)
                    .UseCollation("Croatian_CI_AS");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Kupci)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Kupac_Grad");
            });

            modelBuilder.Entity<Potkategorija>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_PotkategorijaProizvoda");

                entity.ToTable("Potkategorija");

                entity.Property(e => e.Id).HasColumnName("IDPotkategorija");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Potkategorije)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Potkategorija_Kategorija");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Proizvod");

                entity.Property(e => e.Id).HasColumnName("IDProizvod");

                entity.Property(e => e.Boja)
                    .HasMaxLength(15)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.BrojProizvoda)
                    .IsRequired()
                    .HasMaxLength(25)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.CijenaBezPdv)
                    .HasColumnType("money")
                    .HasColumnName("CijenaBezPDV");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.PotkategorijaId).HasColumnName("PotkategorijaID");

                entity.HasOne(d => d.Potkategorija)
                    .WithMany(p => p.Proizvodi)
                    .HasForeignKey(d => d.PotkategorijaId)
                    .HasConstraintName("FK_Proizvod_Potkategorija");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Racun");

                entity.Property(e => e.Id).HasColumnName("IDRacun");

                entity.Property(e => e.BrojRacuna)
                    .IsRequired()
                    .HasMaxLength(25)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.DatumIzdavanja).HasColumnType("datetime");

                entity.Property(e => e.Komentar)
                    .HasMaxLength(128)
                    .UseCollation("Croatian_CI_AS");

                entity.Property(e => e.KomercijalistId).HasColumnName("KomercijalistID");

                entity.Property(e => e.KreditnaKarticaId).HasColumnName("KreditnaKarticaID");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.HasOne(d => d.Komercijalist)
                    .WithMany(p => p.Racuni)
                    .HasForeignKey(d => d.KomercijalistId)
                    .HasConstraintName("FK_Racun_Komercijalist");

                entity.HasOne(d => d.KreditnaKartica)
                    .WithMany(p => p.Racuni)
                    .HasForeignKey(d => d.KreditnaKarticaId)
                    .HasConstraintName("FK_Racun_KreditnaKartica");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Racuni)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Racun_Kupac");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Stavka");

                entity.Property(e => e.Id).HasColumnName("IDStavka");

                entity.Property(e => e.CijenaPoKomadu).HasColumnType("money");

                entity.Property(e => e.PopustUpostocima)
                    .HasColumnType("money")
                    .HasColumnName("PopustUPostocima");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.Property(e => e.RacunId).HasColumnName("RacunID");

                entity.Property(e => e.UkupnaCijena).HasColumnType("numeric(38, 6)");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stavka_Proizvod");

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.RacunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stavka_Racun");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
