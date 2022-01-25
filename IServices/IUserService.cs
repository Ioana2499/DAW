using Playlist_Manager.Entities;
using Playlist_Manager.Models;
using System.Collections.Generic;

namespace Playlist_Manager.IServices
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        bool Register(AuthenticationRequest request);
        AuthenticationResponse Login(AuthenticationRequest request);
    }
}
