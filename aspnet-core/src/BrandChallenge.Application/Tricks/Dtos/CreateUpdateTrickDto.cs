using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BrandChallenge.Tricks
{
    [AutoMapFrom(typeof(Trick))]
    public class CreateUpdateTrickDto: AuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
        public Guid? ChallengeId { get; set; }
    }
}
