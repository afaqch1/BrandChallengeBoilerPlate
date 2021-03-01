using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandChallenge.Dashboard.Dtos
{
    public class DashboardDto : AuditedEntityDto<Guid>
    {
        public string UserName{ get; set; }

        public int? Points { get; set; } = 0;
    }
}
