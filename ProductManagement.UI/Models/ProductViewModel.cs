using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.UI.Models
{
    public class ProductViewModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "${0:C0}")]
        public decimal Price { get; set; }
    }
}
