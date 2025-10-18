using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public ClientType Type { get; set; }
    }
}
