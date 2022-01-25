using Playlist_Manager.Models;
using System.Collections.Generic;

namespace Playlist_Manager.IServices
{
    public interface ISongService
    {
        List<SongModel> GetAllSongs();
        void AddSong(SongModel song);
        void UpdateSong(SongModel song);
        void DeleteSong(int songId);
        void HardDeleteSong(SongModel song);
    }
}
