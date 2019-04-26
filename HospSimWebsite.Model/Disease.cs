using System.Collections.Generic;

namespace HospSimWebsite.Model
{
    public class Disease
    {
        public Disease(int id, string name, int duration, int severity, List<string> descriptions)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Severity = severity;
            Descriptions = descriptions;
        }

        public int Id { get; }
        public string Name { get; }
        public int Duration { get; }
        public int Severity { get; }
        public List<string> Descriptions { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}