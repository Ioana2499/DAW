using Playlist_Manager.Entities;

namespace Playlist_Manager.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUserAndPassword(string username, string password);
    }
}
