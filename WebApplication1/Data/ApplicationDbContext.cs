using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DJ_s_League.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DJ_s_League.Models.Detail> Detail { get; set; } = default!;
        public DbSet<DJ_s_League.Models.Game> Game { get; set; } = default!;
        public DbSet<DJ_s_League.Models.Match> Match { get; set; } = default!;
        public DbSet<DJ_s_League.Models.PricePool> PricePool { get; set; } = default!;
        public DbSet<DJ_s_League.Models.Region> Region { get; set; } = default!;
        public DbSet<DJ_s_League.Models.Team> Team { get; set; } = default!;
        public DbSet<DJ_s_League.Models.Tournament> Tournament { get; set; } = default!;
    }
}
