using Playlist_Manager.Entities;
using Playlist_Manager.IRepository;
using Playlist_Manager.IServices;
using Playlist_Manager.Models;
using System.Collections.Generic;
using System.Linq;

namespace Playlist_Manager.Services
{
    public class SongService: ISongService
    {
        private readonly ISongRepository _songRepository;
        public SongService(ISongRepository songRepository)
        {
            this._songRepository = songRepository;
        }

        public List<SongModel> GetAllSongs()
        {
            return _songRepository.GetAllActive().Select(song => new SongModel() { Id = song.Id, Name = song.Name, Artist = song.Artist }).ToList();
        }

        public void AddSong(SongModel song)
        {
            Song newSong = new Song()
            {
                Name = song.Name,
                Artist = song.Artist,
                IsDeleted = false
            };
            _songRepository.Create(newSong);
            _songRepository.SaveChanges();
        }

        public void UpdateSong(SongModel song)
        {
            var existingSong = _songRepository.FindById(song.Id);
            existingSong.Name = song.Name;
            existingSong.Artist = song.Artist;

        }

        public void DeleteSong(int id)
        {
            var existingSong = _songRepository.FindById(id);
            existingSong.IsDeleted = true;
            existingSong.PlayLists = null;
            _songRepository.Update(existingSong);
            _songRepository.SaveChanges();
        }

        public void HardDeleteSong(SongModel song)
        {
            var existingSong = _songRepository.FindById(song.Id);
            _songRepository.HardDelete(existingSong);
            _songRepository.SaveChanges();
        }
    }
}
