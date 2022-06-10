using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Entity.Dto
{
    public class CreateProductSparepartDto
    {
        [Required]
        public int SparepartID { get; set; }
        [Required]
        public int ProductID { get; set; }
    }
}
