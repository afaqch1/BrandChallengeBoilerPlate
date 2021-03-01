using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrandChallenge.Challenges
{
    [AutoMapFrom(typeof(Challenge))]
    public class ChallengeDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public Guid? BrandId { get; set; }
    }
}
