using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Models
{
    internal class Sale
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public Customer customer { get; set; }
        public Store store { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }

        public DateTime Date { get; set; }


    }
}
