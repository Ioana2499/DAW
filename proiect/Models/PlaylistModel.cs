using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Manager.Models
{
    public class PlaylistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SongModel> SongList { get; set; }
    }
}
