using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Inventory
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private Country(string name)
        {
            Name = name;
        }

        public static Country Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre del país no puede estar vacío.");
            }
            return new Country(name);
        }
    }
}
