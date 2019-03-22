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

        public List<string> Descriptions => _descriptions;

        private int id;
        private string name;
        private int duration;
        private int severity;
        private List<String> _descriptions;
        public Disease(int id, string name, int duration, int severity, List<String> descriptions)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.severity = severity;
            this._descriptions = descriptions;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}