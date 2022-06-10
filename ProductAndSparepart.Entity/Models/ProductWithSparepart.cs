using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Entity.Models
{
    public class ProductWithSparepart
    {
        public int SparepartID { get; set; }
        public Sparepart Sparepart { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
