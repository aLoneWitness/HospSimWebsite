using System.Collections.Generic;

namespace HospSimWebsite.Model
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }
        public string Username { get; }
        public List<Patient> Patients { get; }
        public Doctor Doctor { get; }
    }
}