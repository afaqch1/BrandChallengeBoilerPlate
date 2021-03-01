using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrandChallenge.Tricks
{
    [AutoMapFrom(typeof(Trick))]
    public class TrickDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public Guid? ChallengeId { get; set; }
    }
}
