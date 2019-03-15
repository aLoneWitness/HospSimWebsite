namespace HospSimWebsite
{
    public class Disease
    {
        public int Id => id;
        public string Name => name;

        public int Duration => duration;

        public int Severity => severity;

        private int id;
        private string name;
        private int duration;
        private int severity;
        public Disease(int id, string name, int duration, int severity)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.severity = severity;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}