using Domain.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public InventoryItemConfiguration() { }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InventoryItem> builder)
        {
            // Define el Esquema "Logistica" y la tabla "Inventario"
            builder.ToTable("Inventario", "Logistica");
            // Define la Clave Primaria (PK)
            builder.HasKey(ii => ii.InventoryItemId);
            // Configura la columna de identidad (IDENTITY)
            builder.Property(ii => ii.InventoryItemId)
                .HasColumnName("InventarioId") // Coincide con el nombre SQL
                .IsRequired();
            // Configura ProductId
            builder.Property(ii => ii.ProductId)
                .HasColumnName("ProductoID")
                .IsRequired();

            builder.HasOne(i => i.Product)
                .WithMany(p => p.InventoryItems)
                .HasForeignKey(i => i.ProductId);

            // Configura WarehouseId
            builder.Property(ii => ii.WarehouseId)
                .HasColumnName("AlmacenID")
                .IsRequired();

            // Configura Quantity
            builder.Property(ii => ii.Quantity)
                .HasColumnName("Stock")
                .IsRequired();

            builder.HasIndex(i => new { i.ProductId, i.WarehouseId }).IsUnique();

            builder.ToTable(t =>
                t.HasCheckConstraint("CK_Inventario_Stock", "[Stock] >= 0"));

            builder.Property(i => i.Version)
                   .IsRowVersion();

        }
    }
}
