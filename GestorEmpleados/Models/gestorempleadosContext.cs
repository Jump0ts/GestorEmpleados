using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestorEmpleados.Models
{
    public partial class gestorempleadosContext : DbContext
    {
       
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

            modelBuilder.Entity<Desarrollador>(entity =>
            {
                entity.ToTable("desarrollador");

                

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

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("imagen")
                    .HasMaxLength(200);

                entity.Property(e => e.PrecioHora).HasColumnName("precio_hora");

                entity.Property(e => e.PrecioHorasExtras).HasColumnName("precio_horas_extras");

                

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


                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("imagen")
                    .HasMaxLength(200);

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

            });

            modelBuilder.Entity<ServiciosLimpieza>(entity =>
            {
                entity.ToTable("servicios_limpieza");


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


                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnName("imagen")
                    .HasMaxLength(200);

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

            });
        }
    }
}
