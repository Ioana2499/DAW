using Playlist_Manager.Entities;
using Playlist_Manager.IRepository;
using Playlist_Manager.IServices;
using Playlist_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Playlist_Manager.Services
{
    public class PlaylistService: IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly ISongRepository _songRepository;
        public PlaylistService(IPlaylistRepository playlistService, ISongRepository songRepository)
        {
            _playlistRepository = playlistService;
            _songRepository = songRepository;
        }

        public List<PlaylistModel> GetAllPlaylists()
        {
            List<PlaylistModel> playlists = new List<PlaylistModel>();
            _playlistRepository.GetAllActive().ForEach(playlist =>
            {
                var songList = playlist.Songs.Select(song => new SongModel()
                {
                    Id = song.Id,
                    Artist = song.Artist,
                    Name = song.Name
                }).ToList();
                playlists.Add(new PlaylistModel()
                {
                    Id = playlist.Id,
                    Name = playlist.Name,
                    SongList = songList
                });
            });
            return playlists;
        }
        
        public void CreatePlaylist(PlaylistModel playlist)
        {
            Playlist newPlaylist = new Playlist();
            newPlaylist.Name = playlist.Name;
            newPlaylist.Songs = _songRepository.GetAllActive().Where(song => playlist.SongList.Select(s => s.Id).Contains(song.Id)).ToList();
            _playlistRepository.Create(newPlaylist);
            _playlistRepository.SaveChanges();
        }

        public void UpdatePlaylist(PlaylistModel playlist)
        {
            Playlist existingPlaylist = _playlistRepository.FindById(playlist.Id);
            existingPlaylist.Name = playlist.Name;
            existingPlaylist.Songs = _songRepository.GetAllActive().Where(song => playlist.SongList.Select(s => s.Id).Contains(song.Id)).ToList();
            _playlistRepository.Update(existingPlaylist);
            _playlistRepository.SaveChanges();
        }

        public void DeletePlaylist(int id)
        {
            Playlist existingPlaylist = _playlistRepository.FindById(id);
            existingPlaylist.IsDeleted = true;
            _playlistRepository.Update(existingPlaylist);
            _playlistRepository.SaveChanges();
        }
    }
}
