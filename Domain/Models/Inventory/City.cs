using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Inventory
{
    public class City
    {

        private City(string name) { Name = name; }
        public int CityId { get; private set; }
        public string Name { get; private set; }

        public int StateId { get; private set; }
        public State State { get; private set; }

        public static City Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre de la ciudad no puede estar vacío.");
            }
            return new City(name);
        }
    }
}
