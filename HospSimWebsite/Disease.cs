namespace HospSimWebsite
{
    public class Disease
    {
        private string name;
        
        public Disease(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}