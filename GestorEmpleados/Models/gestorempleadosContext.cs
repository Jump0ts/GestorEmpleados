using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestorEmpleados.Models
{
    public partial class gestorempleadosContext : DbContext
    {
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Desarrollador> Desarrollador { get; set; }
        public virtual DbSet<Lenguaje> Lenguaje { get; set; }
        public virtual DbSet<RecursosHumanos> RecursosHumanos { get; set; }
        public virtual DbSet<ServiciosLimpieza> ServiciosLimpieza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("Server=localhost;Database=gestorempleados;User=root;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamento");

                entity.HasIndex(e => e.Nombre)
                    .HasName("nombre_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Desarrollador>(entity =>
            {
                entity.ToTable("desarrollador");

                entity.HasIndex(e => e.dpto)
                    .HasName("fk_dep_idx");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Lenguaje)
                    .HasName("fk_lenguaje_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasColumnName("apellido2")
                    .HasMaxLength(15);

                entity.Property(e => e.dpto).HasColumnName("departamento");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(10);

                entity.Property(e => e.HorasSemanales).HasColumnName("horas_semanales");

                entity.Property(e => e.Lenguaje).HasColumnName("lenguaje");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20);

                entity.Property(e => e.PrecioHora).HasColumnName("precio_hora");

                entity.Property(e => e.PrecioHorasExtras).HasColumnName("precio_horas_extras");

                entity.HasOne(d => d.DepartamentoNavigation)
                    .WithMany(p => p.Desarrollador)
                    .HasForeignKey(d => d.dpto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_desarrollador");

                entity.HasOne(d => d.LenguajeNavigation)
                    .WithMany(p => p.Desarrollador)
                    .HasForeignKey(d => d.Lenguaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lenguaje_desarrollador");
            });

            modelBuilder.Entity<Lenguaje>(entity =>
            {
                entity.ToTable("lenguaje");

                entity.HasIndex(e => e.Nombre)
                    .HasName("nombre_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<RecursosHumanos>(entity =>
            {
                entity.ToTable("recursos_humanos");

                entity.HasIndex(e => e.dpto)
                    .HasName("fk_dep_rrhh_idx");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasColumnName("apellido2")
                    .HasMaxLength(15);

                entity.Property(e => e.dpto).HasColumnName("departamento");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(10);

                entity.Property(e => e.Funciones)
                    .IsRequired()
                    .HasColumnName("funciones")
                    .HasMaxLength(500);

                entity.Property(e => e.HorasSemanales).HasColumnName("horas_semanales");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20);

                entity.Property(e => e.PrecioHora).HasColumnName("precio_hora");

                entity.Property(e => e.PrecioHorasExtras).HasColumnName("precio_horas_extras");

                entity.HasOne(d => d.DepartamentoNavigation)
                    .WithMany(p => p.RecursosHumanos)
                    .HasForeignKey(d => d.dpto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_rrhh");
            });

            modelBuilder.Entity<ServiciosLimpieza>(entity =>
            {
                entity.ToTable("servicios_limpieza");

                entity.HasIndex(e => e.dpto)
                    .HasName("fk_dep_limpieza_idx");

                entity.HasIndex(e => e.Dni)
                    .HasName("dni_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasColumnName("apellido2")
                    .HasMaxLength(15);

                entity.Property(e => e.AreaLimpieza)
                    .IsRequired()
                    .HasColumnName("area_limpieza")
                    .HasMaxLength(500);

                entity.Property(e => e.dpto).HasColumnName("departamento");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(10);

                entity.Property(e => e.HorasSemanales).HasColumnName("horas_semanales");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(20);

                entity.Property(e => e.PrecioHora).HasColumnName("precio_hora");

                entity.Property(e => e.PrecioHorasExtras).HasColumnName("precio_horas_extras");

                entity.HasOne(d => d.DepartamentoNavigation)
                    .WithMany(p => p.ServiciosLimpieza)
                    .HasForeignKey(d => d.dpto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_limpieza");
            });
        }
    }
}
