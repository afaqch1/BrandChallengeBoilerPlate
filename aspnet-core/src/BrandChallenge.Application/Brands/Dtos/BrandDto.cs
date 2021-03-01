using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrandChallenge.Brands
{
    [AutoMapFrom(typeof(Brand))]
    public class BrandDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
    }
}
