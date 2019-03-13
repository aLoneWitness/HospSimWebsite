using Microsoft.IdentityModel.Xml;

namespace HospSimWebsite
{
    public class Patient
    {
        private int id;
        private string name;
        private int age;

        public Patient(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }
        public int Id
        {
            get => id;
            private set => id = value;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public int Age
        {
            get => age;
            private set => age = value;
        }
    }
}