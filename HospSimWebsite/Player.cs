namespace HospSimWebsite
{
    public class Player : IHuman
    {
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Doctorname
        {
            get => doctorname;
            set => doctorname = value;
        }

        public int Score
        {
            get => score;
            set => score = value;
        }

        private int id;
        private string username;
        private string doctorname;
        private int score;
        
        public Player(int id, string username, string name)
        {
            this.doctorname = name;
            this.username = username;
            this.id = id;
        }

        public string Name { get; }
    }
}