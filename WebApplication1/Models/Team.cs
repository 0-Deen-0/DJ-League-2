namespace DJ_s_League.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public int NumOfPlayer { get; set; }

        public ICollection<Match> Matches { get; set; }

        public Region Region { get; set; }
        
    }
}
