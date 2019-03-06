namespace Fixtures.API.Helpers
{
    public class UserParams
    {
        public int PageNumber { get; set; }
        public int MaxPageSize { get; set; }
        public bool? IsFixtureCompleted { get; set; }
    }
}