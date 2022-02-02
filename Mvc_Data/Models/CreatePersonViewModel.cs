using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Data.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public int Phone { get; set; }
        
        
    }
}
