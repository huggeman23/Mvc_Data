using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Data.Models
{
    [Table("Countery")]
    public class Countery
    {
        [Key]
        [Required]
        public string CounteryName { get; set; }
        public List<City> cityList { get; set; }
    }
}
