using AutoMapper;
using MusicCatalogAPI.Models;
using MusicCatalogAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCatalogAPI.MusicCatalogMapper
{
    public class MusicCatalogMappings : Profile
    {
        public MusicCatalogMappings()
        {
            CreateMap<Music, MusicDto>().ReverseMap();
        }
    }
}
