﻿using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO,RegionDTO>().ReverseMap();
            CreateMap<AddWalkRequestDTO,Walk>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap();
        }
    }
}
