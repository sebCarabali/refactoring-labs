using Domain.Models;
using Domain.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Define el Esquema "Ventas" y la tabla "Productos"
            builder.ToTable("Productos", "Logistica");

            // Define la Clave Primaria (PK)
            builder.HasKey(p => p.ProductId);

            // Configura la columna de identidad (IDENTITY)
            builder.Property(p => p.ProductId)
                .HasColumnName("ProductoID") // Coincide con el nombre SQL
                .IsRequired();

            // Configura NombreProducto
            builder.Property(p => p.Name)
                .HasColumnName("NombreProducto")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false); // Importante: .IsUnicode(false) para que use 'varchar' en lugar de 'nvarchar'

            // Configura Categoria
            builder.Property(p => p.CategoryId)
                .HasColumnName("CategoriaId")
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configura Precio
            builder.Property(p => p.Price)
                .HasColumnName("Precio")
                .IsRequired()
                .HasColumnType("decimal(10, 2)"); // Especifica la precisión y escala

            builder.HasMany(p => p.InventoryItems)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            // Configura PrecioConDescuento (anulable)
            /* builder.Property(p => p.DiscountPrice)
                 .HasColumnName("PrecioConDescuento")
                 .IsRequired(false) // Permite valores NULL
                 .HasColumnType("decimal(10, 2)");*/
        }
    }
}
