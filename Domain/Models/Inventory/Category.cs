using Domain.Models.Sales;
using System.ComponentModel.DataAnnotations;
namespace Domain.Models.Inventory
{
    public class Category
    {
        private readonly List<Product> _productsItems = new();
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public IReadOnlyCollection<Product> Products => _productsItems.AsReadOnly();

        private Category(string name)
        {
            Name = name;
        }

        public static Category Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException("El nombre de la categoría no puede estar vacío.");
            }
            return new Category(name);
        }
    }
}
