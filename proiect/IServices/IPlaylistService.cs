using Playlist_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Manager.IServices
{
    public interface IPlaylistService
    {
        List<PlaylistModel> GetAllPlaylists();
        void CreatePlaylist(PlaylistModel playlist);
        void UpdatePlaylist(PlaylistModel playlist);
        void DeletePlaylist(int id);
    }
}
