using System;

namespace Fixtures.API.DTOS
{
    public class FixtureToCreate
    {
        public int Id { get; set; }
        public string HomeTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public string AwayTeamName { get; set; }

        public int AwayTeamScore { get; set; }

        public DateTime TimeOfPlay { get; set; }
        public string  LocationOfPlay { get; set; }
        public bool IsFixtureCompleted { get; set; }
        public int TeamId { get; set; }
    }
}