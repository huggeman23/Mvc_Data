using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Data.Models
{
    [Table("Language")]
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int LanguageID { get; set; }
        [Required]
        public string LanguageName { get; set; }

        public List<PersonLanguage> peapoleList { get; set; }

    }
}
