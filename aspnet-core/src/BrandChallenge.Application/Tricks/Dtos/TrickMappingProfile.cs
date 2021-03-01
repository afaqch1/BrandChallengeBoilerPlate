using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandChallenge.Tricks.Dtos
{
    public class TrickMappingProfile : Profile
    {
        public TrickMappingProfile()
        {
            CreateMap<Trick, TrickDto>();
            CreateMap<CreateUpdateTrickDto, Trick>();
        }
    }
}
