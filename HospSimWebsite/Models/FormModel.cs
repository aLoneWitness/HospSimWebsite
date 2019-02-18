using System.ComponentModel.DataAnnotations;

namespace HospSimWebsite.Models
{
    public class FormModel
    {
        public string InputName { get; set; }
        public string InputAdressText { get; set; }
        public string InputAdressNum { get; set; }
        public string InputDisease { get; set; }
    }
}