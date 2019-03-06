using System.Threading.Tasks;
using Fixtures.API.Models;

namespace Fixtures.API.Data
{
    public class PremierLeagueRepository : IPremierLeagueRepository
    {
        private readonly DataContext _context;

        public PremierLeagueRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Fixture> GetFixtures()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> MakeUserAdmin(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}