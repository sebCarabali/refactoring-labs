using Domain.Models; // Importa tu entidad de dominio
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios", "Seguridad");

            builder.HasKey(u => u.UserId);
            // Configura la PK para que coincida con el DDL (IDENTITY)
            builder.Property(u => u.UserId)
                .HasColumnName("UsuarioID")
                .IsRequired();

            builder.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .HasColumnName("FechaCreacion")
                .IsRequired();
        }
    }
}
