using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Inventory
{
    public class Warehouse
    {
        public int WarehouseId { get; private set; }
        public string Name { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }

        public string Address { get; private set; }

        private Warehouse(string name, int cityId, string address)
        {
            Name = name;
            CityId = cityId;
            Address = address;
        }

        public static Warehouse Create(string name, int cityId, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre del almacén no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("La dirección del almacén no puede estar vacía.");
            }

            return new Warehouse(name, cityId, address);
        }
    }
}
