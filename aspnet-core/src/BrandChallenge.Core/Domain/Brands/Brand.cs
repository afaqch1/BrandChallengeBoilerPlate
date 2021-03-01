using Abp.Domain.Entities.Auditing;
using BrandChallenge.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace BrandChallenge.Brands
{
    public class Brand : AuditedEntity<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
        public ICollection<Challenge> Challenges { get; set; }

    }
}
