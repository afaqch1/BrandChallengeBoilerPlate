using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BrandChallenge.Authorization;
//using BrandChallenge.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandChallenge.Challenges
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class ChallengeAppService :
        AsyncCrudAppService<
            Challenge, //The Challenge entity
            ChallengeDto, //Used to show Challenges
            Guid, //Primary key of the Challenge entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateChallengeDto>, //Used to create/update a Challenge
        IChallengeAppService //implement the IChallengeAppService
    {
        public ChallengeAppService(IRepository<Challenge, Guid> repository)
            : base(repository)
        {
            //GetPolicyName = BrandChallengePermissions.Challenges.Default;
            //GetListPolicyName = BrandChallengePermissions.Challenges.Default;
            //CreatePolicyName = BrandChallengePermissions.Challenges.Create;
            //UpdatePolicyName = BrandChallengePermissions.Challenges.Edit;
            //DeletePolicyName = BrandChallengePermissions.Challenges.Delete;

        }
    }
}
