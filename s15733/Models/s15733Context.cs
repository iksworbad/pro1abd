using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace s15733.Models
{
    public partial class s15733Context : DbContext
    {
        public s15733Context()
        {
        }

        public s15733Context(DbContextOptions<s15733Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s15733;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno);

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasColumnName("nazwisko")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nrtel)
                    .HasColumnName("nrtel")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pizza1)
                    .HasColumnName("pizza")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SkladnikId).HasColumnName("skladnikId");

                entity.HasOne(d => d.Skladnik)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SkladnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skladniki");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Skladnik1)
                    .HasColumnName("skladnik")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.KlientId).HasColumnName("klientId");

                entity.Property(e => e.PizzaId).HasColumnName("pizzaId");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Klient)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZamowienieKlient");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowionaPizza");
            });
        }
    }
}
