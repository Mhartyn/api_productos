using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_Api.Models
{
    public class ProductoVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
		public double SalesPrice { get; set; }

		public ProductoVm()
        {

        }
    }
}
