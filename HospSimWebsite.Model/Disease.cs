using System;
using System.Collections.Generic;

namespace HospSimWebsite
{
    public class Disease
    {
        public int Id => id;
        public string Name => name;

        public int Duration => duration;

        public int Severity => severity;

        public string Description => description;
        
        private int id;
        private string name;
        private int duration;
        private int severity;
        private string description;
        public Disease(int id, string name, int duration, int severity, string description)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.severity = severity;
            this.description = description;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}