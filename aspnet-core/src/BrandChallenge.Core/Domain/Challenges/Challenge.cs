using Abp.Domain.Entities.Auditing;
using BrandChallenge.Brands;
using BrandChallenge.Tricks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BrandChallenge.Challenges
{
    public class Challenge : AuditedEntity<Guid>
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Trick> Tricks { get; set; }
    }
}
