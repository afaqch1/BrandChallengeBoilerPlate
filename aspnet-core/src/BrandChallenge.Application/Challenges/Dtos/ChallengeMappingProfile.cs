using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandChallenge.Challenges.Dtos
{
    public class ChallengeMappingProfile : Profile
    {
        public ChallengeMappingProfile()
        {
            CreateMap<Challenge, ChallengeDto>();
            CreateMap<CreateUpdateChallengeDto, Challenge>();
        }
    }
}
