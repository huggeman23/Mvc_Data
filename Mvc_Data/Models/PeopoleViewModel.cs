using System.Collections.Generic;

namespace Mvc_Data.Models
{
    public class PeopoleViewModel
    {
        public List<CreatePersonViewModel> PersonalStuff { get; set; }

        public string sertchPhrase { get; set; }    

        public PeopoleViewModel(string sertch) { sertchPhrase = sertch; }

    }
}
