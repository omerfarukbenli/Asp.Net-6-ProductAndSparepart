using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Entity.Dto
{
    public class CreateSparepartDto
    {
        [Required]
        public string SparepartCode { get; set; }
        [Required]
        public string SparepartName { get; set; }
        [Required]
        public int SparepartPrice { get; set; }
        [Required]
        public int[] Products { get; set; }
    }
}
