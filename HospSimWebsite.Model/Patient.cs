using HospSimWebsite.Model.Interfaces;

namespace HospSimWebsite.Model
{
    public class Patient : IHuman
    {
        public string Name { get; }
        public int Age { get; }
        public Disease Disease { get; }
        public int Id { get; }
        
        public Patient(int id, string name, int age, Disease disease)
        {
            Name = name;
            Id = id;
            Age = age;
            Disease = disease;
        }
        
        public Patient(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        
    }
}