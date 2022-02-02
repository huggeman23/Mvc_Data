using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Data.Models
{
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage = "A feald is missing input")]
        public string Name { get; set; }
        [Required(ErrorMessage ="A feald is missing input")]
        public string City { get; set; }
        [Required(ErrorMessage = "A feald is missing input")]
        [RegularExpression(@"^\$?\d+(\.(\d{}))?$")]
        public int Phone { get; set; }
        
        
    }
}
