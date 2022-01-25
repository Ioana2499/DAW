using Playlist_Manager.Data;
using Playlist_Manager.Entities;
using Playlist_Manager.IRepository;

namespace Playlist_Manager.Repository
{
    public class SongRepository: GenericRepository<Song>, ISongRepository
    {
        public SongRepository(PlaylistManagerDbContext context) : base(context)
        {
        }
    }
}
