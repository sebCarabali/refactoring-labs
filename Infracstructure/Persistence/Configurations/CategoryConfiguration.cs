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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categorias", "Logistica");

            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryId)
                .HasColumnName("CategoriaID")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("NombreCategoria")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
