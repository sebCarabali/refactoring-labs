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
    public class MovementLogConfiguration : IEntityTypeConfiguration<MovementLog>
    {
        public void Configure(EntityTypeBuilder<MovementLog> builder)
        {
            builder.ToTable("LogMovimientos", "Logistica");

            builder.HasKey(ml => ml.MovementId);

            builder.Property(ml => ml.MovementId)
                .HasColumnName("LogId")
                .IsRequired();

            builder.Property(ml => ml.ProductId)
                .HasColumnName("ProductoId")
                .IsRequired();


            builder.Property(ml =>ml.FromWarehouseId)
                .HasColumnName("OrigenId")
                .IsRequired();

            builder.Property(ml => ml.ToWarehouseId)
                .HasColumnName("DestinoId")
                .IsRequired();

            builder.Property(ml => ml.Quantity)
                .HasColumnName("Cantidad")
                .IsRequired();

            builder.Property(ml => ml.MovementDate)
                .HasColumnName("Fecha")
                .IsRequired();
        }
    }
}
