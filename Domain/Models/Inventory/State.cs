using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Inventory
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        private State(string name)
        {
            this.Name = name;
        }

        public static State Create(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "El nombre del estado no puede ser nulo.");
            return new State(name);
        }
    }
}
