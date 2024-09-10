using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Models
{
    internal class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sale> Sales { get; set; }

    }
}
