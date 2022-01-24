using Microsoft.EntityFrameworkCore;
using Playlist_Manager.Entities;

namespace Playlist_Manager.Data
{
    public class PlaylistManagerDbContext : DbContext
    {
        public PlaylistManagerDbContext(DbContextOptions<PlaylistManagerDbContext> options) : base(options) { 

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistEditor> PlaylistEditors { get; set; }
    }
}
