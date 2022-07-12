using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCatalogAPI.Models;
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

        [HttpPost]
        public IActionResult CreateMusic([FromBody] MusicDto musicDto)
        {
            if (musicDto == null)
            {
                return BadRequest(ModelState);
            }
            var music = _mapper.Map<Music>(musicDto);
            if (!_musicRepository.CreateMusic(music))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {music.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetMusic", new { musicId = music.Id }, music);
        }

        [HttpPatch("{musicId:int}", Name = "UpdateMusic")]
        public IActionResult UpdateMusic(int musicId,[FromBody] MusicDto musicDto)
        {
            if (musicDto == null || musicId != musicDto.Id)
            {
                return BadRequest(ModelState);
            }
            var music = _mapper.Map<Music>(musicDto);
            if (!_musicRepository.UpdateMusic(music))
            {
                ModelState.AddModelError("", $"Something went wrong when update the record {music.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{musicId:int}", Name = "DeleteMusic")]
        public IActionResult DeleteMusic(int musicId)
        {
            if (!_musicRepository.MusicExists(musicId))
            {
                return NotFound();
            }
           
            var music = _musicRepository.GetMusic(musicId);
           
            if (!_musicRepository.DeleteMusic(music))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {music.Id}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
