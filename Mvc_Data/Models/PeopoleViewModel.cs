using System.Collections.Generic;

namespace Mvc_Data.Models
{
    public class PeopoleViewModel
    {
        public List<Person> PersonalStuff { get; set; }

        public string sertchPhrase { get; set; }    

        public PeopoleViewModel(string sertch) { sertchPhrase = sertch; }

    }
}
