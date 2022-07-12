using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCatalogAPI.Models.Dtos;
using MusicCatalogAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private IMusicRepository _musicRepository;
        private readonly IMapper _mapper;
        public MusicController(IMusicRepository musicRepository, IMapper mapper)
        {
            _musicRepository = musicRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMusics()
        {
            var musics = _musicRepository.GetMusics();
            var musicsDto = new List<MusicDto>();

            foreach (var music in musics)
            {
                musicsDto.Add(_mapper.Map<MusicDto>(music));
            }
            return Ok(musicsDto);
        }

        [HttpGet("{musicId:int}")]
        public IActionResult GetMusic(int musicId)
        {
            var music = _musicRepository.GetMusic(musicId);
            if (music == null)
            {
                return NotFound();
            }
            var musicDto = _mapper.Map<MusicDto>(music);
            return Ok(musicDto);
        }
    }
}
