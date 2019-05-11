using HospSimWebsite.Model.Interfaces;

namespace HospSimWebsite.Model
{
    public class Patient : IHuman
    {
        public int Age { get; set; }
        public Disease Disease { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}