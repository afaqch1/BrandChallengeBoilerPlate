using Abp.Domain.Entities.Auditing;
using BrandChallenge.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BrandChallenge.Tricks
{
    public class Trick : AuditedEntity<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public Guid ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
    }
}
