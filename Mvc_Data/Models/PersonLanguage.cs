using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Data.Models
{
    [Table("PersonLanguage")]
    public class PersonLanguage
    {
        
        [ForeignKey("Id")]
        public Person Person { get; set; }
        public int Id { get; set; }
        
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public int LanguageID { get; set; }
    }
}
