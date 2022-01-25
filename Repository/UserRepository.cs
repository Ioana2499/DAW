using Playlist_Manager.Data;
using Playlist_Manager.Entities;
using Playlist_Manager.IRepository;
using System.Linq;

namespace Playlist_Manager.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PlaylistManagerDbContext context) : base(context)
        {
        }

        public User GetByUserAndPassword(string username, string password)
        {
            return _table.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }
    }
}
