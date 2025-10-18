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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clientes", "Ventas");

            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.ClientId)
                .HasColumnName("ClienteID")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(c => c.Type)
                .HasColumnName("Tipo")
                .HasConversion(
                    v => ConvertToString(v),
                    v => ConvertToEnum(v)
                )
                .HasMaxLength(50)
                .IsRequired();
        }

        private static string ConvertToString(ClientType v)
        {
            return v switch
            {
                ClientType.VIP => "VIP",
                ClientType.Member => "Miembro",
                ClientType.Regular => "Regular",
                _ => "Regular"
            };
        }

        private static ClientType ConvertToEnum(string v)
        {
            return v switch
            {
                "VIP" => ClientType.VIP,
                "Miembro" => ClientType.Member,
                "Regular" => ClientType.Regular,
                _ => ClientType.Regular
            };
        }
    }
}
