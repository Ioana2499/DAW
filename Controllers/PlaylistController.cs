using Microsoft.AspNetCore.Mvc;
using Playlist_Manager.Helpers;
using Playlist_Manager.IServices;
using Playlist_Manager.Models;

namespace Playlist_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_playlistService.GetAllPlaylists());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(PlaylistModel playlist)
        {
            _playlistService.CreatePlaylist(playlist);
            return Ok(_playlistService.GetAllPlaylists());
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _playlistService.DeletePlaylist(id);
            return Ok(_playlistService.GetAllPlaylists());
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put(PlaylistModel playlist)
        {
            _playlistService.UpdatePlaylist(playlist);
            return Ok(_playlistService.GetAllPlaylists());
        }

    }
}
