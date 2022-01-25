using Playlist_Manager.Data;
using Playlist_Manager.Entities;
using Playlist_Manager.IRepository;
using Playlist_Manager.Repository;

namespace Playlist_Manager.Services
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(PlaylistManagerDbContext context) : base(context)
        {

        }
    }
}
