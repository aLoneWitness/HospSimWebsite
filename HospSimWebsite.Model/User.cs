using System.Collections.Generic;

namespace HospSimWebsite.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Patient> Patients { get; set; }
        public Doctor Doctor { get; set; }
        public int Highscore { get; set; }
    }
}