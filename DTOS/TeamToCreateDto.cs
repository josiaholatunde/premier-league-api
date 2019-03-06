using System;

namespace Fixtures.API.DTOS
{
    public class TeamToCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationDto City { get; set; }
        public string Country { get; set; }
        public double FanStrength { get; set; }
        public string StadiumName { get; set; }
        public string NameOfManager { get; set; }
        public DateTime YearFounded { get; set; }
    }
}