using HospSimWebsite.Interfaces;
using Microsoft.IdentityModel.Xml;

namespace HospSimWebsite
{
    public class Patient : IHuman
    {
        private string name;
        private int age;

        public Patient(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get => name;
        }

        public int Age
        {
            get => age;
        }

        public Disease Disease { get; }
    }
}