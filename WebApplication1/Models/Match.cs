namespace DJ_s_League.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public TimeOnly MatchTime   { get; set; }
        public string Result { get; set; }

        public Tournament Tournament { get; set; }

    }
}
