using MusicCatalogAPI.Data;
using MusicCatalogAPI.Repository.IRepository;
using MusicCatalogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCatalogAPI.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly ApplicationDbContext _db;
        public MusicRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateMusic(Music music)
        {
            _db.Musics.Add(music);
            return Save();
        }

        public bool DeleteMusic(Music music)
        {
            _db.Musics.Remove(music);
            return Save();
        }

        public Music GetMusic(int musicId)
        {
            var music = _db.Musics.FirstOrDefault(x => x.Id == musicId);
            return music;
        }

        public ICollection<Music> GetMusics()
        {
            var musics = _db.Musics.OrderBy(x => x.Name).ToList();
            return musics;
        }

        public bool MusicExists(string name)
        {
            bool exists = _db.Musics.Any(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
            return exists;
        }

        public bool MusicExists(int musicId)
        {
            bool exists = _db.Musics.Any(x => x.Id == musicId);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateMusic(Music music)
        {
            _db.Musics.Update(music);
            return Save();
        }
    }
}
