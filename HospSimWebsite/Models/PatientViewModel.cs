using HospSimWebsite.Model;

namespace HospSimWebsite.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        
        public DiseaseViewModel Disease { get; set; }
    }
}