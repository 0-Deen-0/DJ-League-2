namespace DJ_s_League.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<Tournament> Tournament { get; set; }



    }
}
