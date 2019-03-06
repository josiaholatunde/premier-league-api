using System;

namespace Fixtures.API.DTOS
{
    public class TeamToCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationDto Location { get; set; }
        public double FanStrength { get; set; }
        public string StadiumName { get; set; }
        public string NameOfManager { get; set; }
        public DateTime YearFounded { get; set; }
        public string LogoUrl { get; set; }
    }
}