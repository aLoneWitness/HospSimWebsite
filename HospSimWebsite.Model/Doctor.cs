using HospSimWebsite.Model.Interfaces;

namespace HospSimWebsite.Model
{
    public class Doctor : IHuman
    {
        public Doctor(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}