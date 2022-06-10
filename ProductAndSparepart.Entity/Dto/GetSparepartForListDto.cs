using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Entity.Dto
{
    public class GetSparepartForListDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SparepartCode { get; set; }
        public string SparepartName { get; set; }
        public int SparepartPrice { get; set; }

        public IEnumerable<string> Products { get; set; }
    }
}
