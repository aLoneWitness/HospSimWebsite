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
        public int Highscore { get; }

        public User(int id, string name, string username, List<Patient> patients, Doctor doctor, int highscore = 0)
        {
            Id = id;
            Name = name;
            Username = username;
            Patients = patients;
            Doctor = doctor;
            Highscore = highscore;
        }
    }
    
    
}