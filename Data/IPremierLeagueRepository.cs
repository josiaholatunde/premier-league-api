using System.Threading.Tasks;
using Fixtures.API.Helpers;
using Fixtures.API.Models;

namespace Fixtures.API.Data
{
    public interface IPremierLeagueRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        Task<bool> SaveAllChangesAsync();
        Task<Fixture> GetFixtures();

        Task<User> GetUser(int userId);
        Task<bool> MakeUserAdmin(User user);

    }
}