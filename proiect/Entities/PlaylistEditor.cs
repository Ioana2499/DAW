using System.Collections.Generic;

namespace Playlist_Manager.Entities
{
    public class PlaylistEditor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Song> AddedSongs { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
