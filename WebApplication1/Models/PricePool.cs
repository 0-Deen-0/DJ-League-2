namespace DJ_s_League.Models
{
    public class PricePool
    {
        public int Id { get; set; } 
        public int TournamentId { get; set; }
        public int TotalAmount { get; set; }
        public string Currency { get; set; }
        public int PriceForTop10 { get; set; }
        public int PriceForTop5 { get; set; }
        public int PriceForTop1 { get; set; }

        public Tournament? Tournament { get; set; }


    }
}
