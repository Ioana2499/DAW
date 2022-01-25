using System.ComponentModel.DataAnnotations;

namespace Playlist_Manager.Models
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
