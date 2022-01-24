using System.Collections.Generic;

namespace Playlist_Manager.Entities
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public virtual ICollection<Playlist> PlayLists { get; set; } 
    }
}
