using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIN_projekt.Model
{
    public partial class PIN_clanoviContext : DbContext
    {
        public virtual DbSet<Clanovi> Clanovi { get; set; }
        public virtual DbSet<Grupa> Grupa { get; set; }
        public virtual DbSet<Svojstvo> Svojstvo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=N007282\SQLEXPRESS;Initial Catalog=PIN_clanovi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clanovi>(entity =>
            {
                entity.HasKey(e => e.ClanId);

                entity.ToTable("CLANOVI");

                entity.HasIndex(e => e.ClanId)
                    .HasName("uniqueIme")
                    .IsUnique();

                entity.Property(e => e.ClanId).HasColumnName("CLAN_ID");

                entity.Property(e => e.ClanAktivan).HasColumnName("CLAN_AKTIVAN");

                entity.Property(e => e.ClanBrojNoge).HasColumnName("CLAN_BROJ_NOGE");

                entity.Property(e => e.ClanClanOd)
                    .HasColumnName("CLAN_CLAN_OD")
                    .HasColumnType("date");

                entity.Property(e => e.ClanDatumRodenja)
                    .HasColumnName("CLAN_DATUM_RODENJA")
                    .HasColumnType("date");

                entity.Property(e => e.ClanEmail)
                    .HasColumnName("CLAN_EMAIL")
                    .HasMaxLength(90);

                entity.Property(e => e.ClanGrupa).HasColumnName("CLAN_GRUPA");

                entity.Property(e => e.ClanIme)
                    .IsRequired()
                    .HasColumnName("CLAN_IME")
                    .HasMaxLength(30);

                entity.Property(e => e.ClanPrezime)
                    .IsRequired()
                    .HasColumnName("CLAN_PREZIME")
                    .HasMaxLength(30);

                entity.Property(e => e.ClanSvojstvo).HasColumnName("CLAN_SVOJSTVO");

                entity.Property(e => e.ClanTelefon)
                    .HasColumnName("CLAN_TELEFON")
                    .HasMaxLength(20);

                entity.Property(e => e.ClanVisina).HasColumnName("CLAN_VISINA");

                entity.HasOne(d => d.ClanGrupaNavigation)
                    .WithMany(p => p.Clanovi)
                    .HasForeignKey(d => d.ClanGrupa)
                    .HasConstraintName("FK_CLANOVI_GRUPA");

                entity.HasOne(d => d.ClanSvojstvoNavigation)
                    .WithMany(p => p.Clanovi)
                    .HasForeignKey(d => d.ClanSvojstvo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLANOVI__SVOJSTVO");
            });

            modelBuilder.Entity<Grupa>(entity =>
            {
                entity.ToTable("GRUPA");

                entity.Property(e => e.GrupaId)
                    .HasColumnName("GRUPA_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GrupaAktivan).HasColumnName("GRUPA_AKTIVAN");

                entity.Property(e => e.GrupaDatumOd)
                    .HasColumnName("GRUPA_DATUM_OD")
                    .HasColumnType("date");

                entity.Property(e => e.GrupaNaziv)
                    .HasColumnName("GRUPA_NAZIV")
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<Svojstvo>(entity =>
            {
                entity.ToTable("SVOJSTVO");

                entity.HasIndex(e => e.SvojstvoNaziv)
                    .HasName("uniqueSvojstvo")
                    .IsUnique();

                entity.Property(e => e.SvojstvoId).HasColumnName("SVOJSTVO_ID");

                entity.Property(e => e.SvojstvoAktivan).HasColumnName("SVOJSTVO_AKTIVAN");

                entity.Property(e => e.SvojstvoNaziv)
                    .IsRequired()
                    .HasColumnName("SVOJSTVO_NAZIV")
                    .HasMaxLength(30);
            });
        }
    }
}
