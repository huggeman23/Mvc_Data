using System.Collections.Generic;

namespace Mvc_Data.Models
{
    public class CreatePersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CounteryName { get; set; }
        public string LanguageName { get; set; }
        public int LanguageID { get; set; }

    }
}
