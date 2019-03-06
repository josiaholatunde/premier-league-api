using System;

namespace Fixtures.API.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLogoUrl { get; set; }
        public int HomeTeamScore { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamLogoUrl { get; set; }

        public int AwayTeamScore { get; set; }

        public DateTime TimeOfPlay { get; set; }
        public string  LocationOfPlay { get; set; }
        public bool IsFixtureCompleted { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
        
    }
}