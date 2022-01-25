using Microsoft.AspNetCore.Mvc;
using Playlist_Manager.Helpers;
using Playlist_Manager.IServices;
using Playlist_Manager.Models;

namespace Playlist_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            //var user = HttpContext.Items["User"];
            return Ok(_songService.GetAllSongs());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(SongModel song)
        {
            _songService.AddSong(song);
            return Ok(_songService.GetAllSongs());
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _songService.DeleteSong(id);
            return Ok(_songService.GetAllSongs());
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put(SongModel song)
        {
            _songService.UpdateSong(song);
            return Ok(_songService.GetAllSongs());
        }

    }
}
