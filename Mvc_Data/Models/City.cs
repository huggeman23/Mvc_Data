using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Data.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityID { get; set; }
        [Required]
        public string Name { get; set; }
        
        [ForeignKey("CounteryName")]
        public Countery Countery { get; set; }
        public string CounteryName { get; set; }
        
        public List<Person> peapoleList { get; set; }
        
    }
}
