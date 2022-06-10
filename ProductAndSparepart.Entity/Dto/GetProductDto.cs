using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Entity.Dto
{
    public class GetProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }
}
