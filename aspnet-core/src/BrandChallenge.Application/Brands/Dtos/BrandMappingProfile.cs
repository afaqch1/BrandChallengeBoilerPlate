using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandChallenge.Brands.Dtos
{
    public class BrandMappingProfile: Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<CreateUpdateBrandDto, Brand>();
        }
    }
}
