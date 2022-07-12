using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCatalogAPI.Models;

namespace MusicCatalogAPI.Repository.IRepository
{
    public interface IMusicRepository
    {
        ICollection<Music> GetMusics();
        Music GetMusic(int musicId);
        bool MusicExists(string name);
        bool MusicExists(int musicId);
        bool CreateMusic(Music music);
        bool UpdateMusic(Music music);
        bool DeleteMusic(Music music);
        bool Save();
    }
}
