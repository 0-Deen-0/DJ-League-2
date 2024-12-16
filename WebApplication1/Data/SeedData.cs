using DJ_s_League.Models;
using WebApplication1.Data;

namespace DJ_League.Data
{
    public class SeedData
    {
        public static void SeedGames(ApplicationDbContext context)
        {
            if (!context.Game.Any()) // Check if there are any games already in the database
            {
                var games = new List<Game>
                {
                    new Game
                    {
                        Name = "Fortnite"
                    },
                    new Game
                    {
                        Name = "CSGO"
                    },
                    new Game
                    {
                        Name = "Call of Duty"
                    }
                };

                context.Game.AddRange(games);
                context.SaveChanges();
            }
        }

        public static void SeedRegions(ApplicationDbContext context)
        {
            if (!context.Region.Any()) // Check if there are any regions already in the database
            {
                var regions = new List<Region>
                {
                    new Region
                    {
                        Name = "North America"
                    },
                    new Region
                    {
                        Name = "Europe"
                    }
                };

                context.Region.AddRange(regions);
                context.SaveChanges();
            }
        }

        public static void SeedTeams(ApplicationDbContext context)
        {
            if (!context.Team.Any()) // Check if there are any teams already in the database
            {
                var teams = new List<Team>
                {
                    // Teams for North America
                    new Team
                    {
                        Name = "Faze",
                        NumOfPlayer = 5,
                        RegionId = context.Region.FirstOrDefault(r => r.Name == "North America").Id
                    },
                    new Team
                    {
                        Name = "Heroic",
                        NumOfPlayer = 4,
                        RegionId = context.Region.FirstOrDefault(r => r.Name == "North America").Id
                    },

                    // Teams for Europe
                    new Team
                    {
                        Name = "Optic",
                        NumOfPlayer = 5,
                        RegionId = context.Region.FirstOrDefault(r => r.Name == "Europe").Id
                    },
                    new Team
                    {
                        Name = "Minnesota Rockers",
                        NumOfPlayer = 4,
                        RegionId = context.Region.FirstOrDefault(r => r.Name == "Europe").Id
                    }
                };

                context.Team.AddRange(teams);
                context.SaveChanges();
            }
        }

        public static void SeedTournaments(ApplicationDbContext context)
        {
            if (!context.Tournament.Any()) // Check if there are any tournaments already in the database
            {
                var tournaments = new List<Tournament>
                {
                    // Tournaments for each game
                    new Tournament
                    {
                        GameId = context.Game.FirstOrDefault(g => g.Name == "Fortnite").Id,
                        Name = "FNCS Season 1",
                        Description = "Top Fortnite Tournament"
                    },
                    new Tournament
                    {
                        GameId = context.Game.FirstOrDefault(g => g.Name == "CSGO").Id,
                        Name = "CSGO Pro League",
                        Description = "Top CSGO Tournament"
                    },
                    new Tournament
                    {
                        GameId = context.Game.FirstOrDefault(g => g.Name == "Call of Duty").Id,
                        Name = "COD Game Battles",
                        Description = "Top Call of Duty Tournament"
                    }
                };

                context.Tournament.AddRange(tournaments);
                context.SaveChanges();
            }
        }

        public static void SeedPricePools(ApplicationDbContext context)
        {
            if (!context.PricePool.Any()) // Check if there are any price pools already in the database
            {
                var pricePools = new List<PricePool>
                {
                    new PricePool
                    {
                        TournamentId = context.Tournament.FirstOrDefault(t => t.Name == "FNCS Season 1").Id,
                        TotalAmount = 1000000,
                        Currency = "USD",
                        PriceForTop10 = 10000,
                        PriceForTop5 = 50000,
                        PriceForTop1 = 300000
                    },
                    new PricePool
                    {
                        TournamentId = context.Tournament.FirstOrDefault(t => t.Name == "CSGO Pro League").Id,
                        TotalAmount = 500000,
                        Currency = "USD",
                        PriceForTop10 = 5000,
                        PriceForTop5 = 25000,
                        PriceForTop1 = 150000
                    },
                    new PricePool
                    {
                        TournamentId = context.Tournament.FirstOrDefault(t => t.Name == "COD Game Battles").Id,
                        TotalAmount = 300000,
                        Currency = "USD",
                        PriceForTop10 = 2000,
                        PriceForTop5 = 10000,
                        PriceForTop1 = 50000
                    }
                };

                context.PricePool.AddRange(pricePools);
                context.SaveChanges();
            }
        }

        public static void SeedMatches(ApplicationDbContext context)
        {
            if (!context.Match.Any()) // Check if there are any matches already in the database
            {
                var matches = new List<Match>
                {
                    // Matches for Fortnite World Cup
                    new Match
                    {
                        TournamentId = context.Tournament.FirstOrDefault(t => t.Name == "FNCS Season 1").Id,
                        MatchTime = new TimeOnly(12, 00),
                        Result = "Victory Royale by Team Faze"
                    },
                    // Matches for CSGO Major
                    new Match
                    {
                        TournamentId = context.Tournament.FirstOrDefault(t => t.Name == "CSGO Pro League").Id,
                        MatchTime = new TimeOnly(14, 30),
                        Result = "2-1, Team Optic wins"
                    },
                    // Matches for Call of Duty League
                    new Match
                    {
                        TournamentId = context.Tournament.FirstOrDefault(t => t.Name == "COD Game Battles").Id,
                        MatchTime = new TimeOnly(18, 00),
                        Result = "3-2, Team Heroic wins"
                    }
                };

                context.Match.AddRange(matches);
                context.SaveChanges();
            }
        }
        public static void SeedDetails(ApplicationDbContext context)
        {
            if (!context.Detail.Any()) // Check if there are any details already in the database
            {
                var details = new List<Detail>
                {
                    new Detail
                    {
                        Name = "DJ League",
                        StartDate = new DateOnly(2024, 12, 11),
                        EndDate = new DateOnly(2024, 12, 20),
                        MinimumLevel = "30" // Players must be at level 30 to participate
                    }
                };

                context.Detail.AddRange(details);
                context.SaveChanges();
            }
        }
    }
}




       
