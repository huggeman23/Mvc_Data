using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Data.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("CityID")]
        public City City{ get; set; }
        public int CityID { get; set; }
       
        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public int Phone { get; set; }

        public List<PersonLanguage> languageList { get; set; }
    }
}
