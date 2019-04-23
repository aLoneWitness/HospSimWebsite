namespace HospSimWebsite.Model
{
    public class Disease
    {
        public int Id { get; }
        public string Name { get; }
        public int Duration { get; }
        public int Severity { get; }
        public string Description { get; }

        public Disease(int id, string name, int duration, int severity, string description)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Severity = severity;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}