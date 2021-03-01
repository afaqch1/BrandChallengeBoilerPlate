using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BrandChallenge.Brands
{
    [AutoMapFrom(typeof(Brand))]
    public class CreateUpdateBrandDto: AuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
