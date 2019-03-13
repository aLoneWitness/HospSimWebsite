using HospSimWebsite.Interfaces;

namespace HospSimWebsite
{
    public class Doctor : IHuman
    {
        private string name;
        private int age;

        public Doctor(string name, int age)
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
    }
}