namespace DJ_s_League.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public Game game { get; set; }

        public ICollection<Match> matches { get; set; }

        public ICollection<PricePool> pricePools { get; set; }

        public ICollection<Region> regions { get; set; }
    }
}
