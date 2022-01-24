using System.Collections.Generic;

namespace Playlist_Manager.Entities
{
    public class Playlist: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
