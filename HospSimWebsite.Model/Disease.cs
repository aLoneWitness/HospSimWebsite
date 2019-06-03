using System.Collections.Generic;

namespace HospSimWebsite.Model
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Severity { get; set; }
        public List<string> Descriptions { get; set; }

    }
}