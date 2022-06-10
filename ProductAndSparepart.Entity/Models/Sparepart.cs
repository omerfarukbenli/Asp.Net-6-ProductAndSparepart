using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Entity.Models
{
    public class Sparepart
    {
        public int Id { get; set; }
        public string SparepartCode { get; set; }
        public string SparepartName { get; set; }
        public int SparepartPrice { get; set; }
        public ICollection<ProductWithSparepart> ProductWithSpareparts { get; set; }
    }
}
