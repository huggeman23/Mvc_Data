using System.Collections.Generic;

namespace Mvc_Data.Models
{
    public class ListViewModel
    {
        public List<Person> peapoleList { get; set; }
        public List<Language> languageList { get; set; }
        public List<City> cityList { get; set; }
        public List<Countery> counteryList { get; set; }

    }
}
