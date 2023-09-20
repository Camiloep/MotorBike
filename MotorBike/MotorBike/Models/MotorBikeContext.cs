using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MotorBike.Models
{
    public partial class MotorBikeContext : IdentityDbContext
    {
        public MotorBikeContext()
        {
        }

        public MotorBikeContext(DbContextOptions<MotorBikeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<CompraXRepuesto> CompraXRepuestos { get; set; } = null!;
        public virtual DbSet<Mecanico> Mecanicos { get; set; } = null!;
        public virtual DbSet<Repuesto> Repuestos { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<VentaXRepuesto> VentaXRepuestos { get; set; } = null!;
        public virtual DbSet<Ventas> Ventas { get; set; } = null!;
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BKNU1NK\\SQLEXPRESS;Initial Catalog=MotorBike;integrated security=True; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5A06C00F40");

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_categoria");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__clientes__677F38F5D3C62D97");

                entity.ToTable("clientes");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion_cliente");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono_cliente");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__compras__C4BAA604F444231B");

                entity.ToTable("compras");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("total");
            });


            modelBuilder.Entity<CompraXRepuesto>(entity =>
            {
                entity.HasKey(e => e.IdCompraXRepuesto)
                    .HasName("PK__compra_x__9AE7DA60F3AD6E9E");

                entity.ToTable("compra_x_repuesto");

                entity.Property(e => e.IdCompraXRepuesto).HasColumnName("id_compra_x_repuesto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FkCategoria).HasColumnName("fk_categoria");

                entity.Property(e => e.FkCompra).HasColumnName("fk_compra");

                entity.Property(e => e.FkRepuesto).HasColumnName("fk_repuesto");

                entity.Property(e => e.PrecioFinal)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_final");

                entity.Property(e => e.PrecioUnitario)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_unitario");

                entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("subtotal");

                entity.HasOne(d => d.FkCategoriaNavigation)
                    .WithMany(p => p.CompraXRepuestos)
                    .HasForeignKey(d => d.FkCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__compra_x___fk_ca__336AA144");

                entity.HasOne(d => d.FkCompraNavigation)
                    .WithMany(p => p.CompraXRepuestos)
                    .HasForeignKey(d => d.FkCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__compra_x___fk_co__32767D0B");

                entity.HasOne(d => d.FkRepuestoNavigation)
                    .WithMany(p => p.CompraXRepuestos)
                    .HasForeignKey(d => d.FkRepuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__compra_x___fk_re__345EC57D");
            });

            modelBuilder.Entity<Mecanico>(entity =>
            {
                entity.HasKey(e => e.IdMecanico)
                    .HasName("PK__mecanico__3228572CA1A6FE10");

                entity.ToTable("mecanicos");

                entity.Property(e => e.IdMecanico).HasColumnName("id_mecanico");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.DireccionMecanico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion_mecanico");

                entity.Property(e => e.NombreMecanico)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre_mecanico");

                entity.Property(e => e.TelefonoMecanico)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono_mecanico");
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.HasKey(e => e.IdRepuesto)
                    .HasName("PK__repuesto__9D97D13F5CACE01D");

                entity.ToTable("repuestos");

                entity.Property(e => e.IdRepuesto).HasColumnName("id_repuesto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FkCategoria).HasColumnName("fk_categoria");

                entity.Property(e => e.NombreRepuesto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_repuesto");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.FkCategoriaNavigation)
                    .WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.FkCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__repuestos__preci__4A8310C6");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__servicio__6FD07FDC7DDB5ECC");

                entity.ToTable("servicios");

                entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_servicio");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__ventas__459533BFE4E9E927");

                entity.ToTable("ventas");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fechaVenta");

                entity.Property(e => e.Total)
                     .HasColumnType("numeric(18, 2)")
                     .HasColumnName("total");
            });

            modelBuilder.Entity<VentaXRepuesto>(entity =>
            {
                entity.HasKey(e => e.IdVentaXRepuesto)
                    .HasName("PK__venta_x___AA09E4D6538D5B10");

                entity.ToTable("venta_x_repuestos");

                entity.Property(e => e.IdVentaXRepuesto).HasColumnName("id_venta_x_repuesto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FkCategoria).HasColumnName("fk_categoria");

                entity.Property(e => e.FkCliente).HasColumnName("fk_cliente");

                entity.Property(e => e.FkMecanico).HasColumnName("fk_mecanico");

                entity.Property(e => e.FkRepuesto).HasColumnName("fk_repuesto");

                entity.Property(e => e.FkServicio).HasColumnName("fk_servicio");

                entity.Property(e => e.FkVenta).HasColumnName("fk_venta");

                entity.Property(e => e.PrecioFinal)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_final");

                entity.Property(e => e.PrecioManoObra)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_mano_obra");

                entity.Property(e => e.PrecioUnitario)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_unitario");

                entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("subtotal");

                entity.HasOne(d => d.FkCategoriaNavigation)
                    .WithMany(p => p.VentaXRepuestos)
                    .HasForeignKey(d => d.FkCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta_x_r__fk_ca__382F5661");

                entity.HasOne(d => d.FkClienteNavigation)
                    .WithMany(p => p.VentaXRepuestos)
                    .HasForeignKey(d => d.FkCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta_x_r__fk_cl__3BFFE745");

                entity.HasOne(d => d.FkMecanicoNavigation)
                    .WithMany(p => p.VentaXRepuestos)
                    .HasForeignKey(d => d.FkMecanico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta_x_r__fk_me__3A179ED3");

                entity.HasOne(d => d.FkRepuestoNavigation)
                    .WithMany(p => p.VentaXRepuestos)
                    .HasForeignKey(d => d.FkRepuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta_x_r__fk_re__39237A9A");

                entity.HasOne(d => d.FkServicioNavigation)
                    .WithMany(p => p.VentaXRepuestos)
                    .HasForeignKey(d => d.FkServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta_x_r__fk_se__3B0BC30C");

                entity.HasOne(d => d.FkVentaNavigation)
                    .WithMany(p => p.VentaXRepuestos)
                    .HasForeignKey(d => d.FkVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta_x_r__fk_ve__373B3228");

                base.OnModelCreating(modelBuilder);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
