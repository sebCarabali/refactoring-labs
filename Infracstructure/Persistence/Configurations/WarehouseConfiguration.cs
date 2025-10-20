using Domain.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public WarehouseConfiguration() { }

        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Almacenes", "Logistica");

            builder.HasKey(w => w.WarehouseId);

            builder.Property(w => w.WarehouseId)
                .HasColumnName("AlmacenID")
                .IsRequired();

            builder.Property(w => w.Name)
                .HasColumnName("NombreAlmacen")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(w => w.CityId)
                .HasColumnName("CiudadID")
                .IsRequired();

            builder.HasOne(w => w.City)
                .WithMany()
                .HasForeignKey(w => w.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(w => w.Address)
                .HasColumnName("Direccion")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
