using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerEntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int Stock { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
