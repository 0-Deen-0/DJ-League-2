namespace DJ_s_League.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
