using HospSimWebsite.Interfaces;

namespace HospSimWebsite
{
    public class Doctor : IHuman
    {
        private string name;
        private int score;
        
        public Doctor(string name, int age)
        {
            this.name = name;
        }

        public string Name
        {
            get => name;
        }

        public int Score
        {
            get => score;
        }

    }
}