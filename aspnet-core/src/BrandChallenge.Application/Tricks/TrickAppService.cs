using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BrandChallenge.Authorization;
using BrandChallenge.Challenges;
//using BrandChallenge.Permissions;
using BrandChallenge.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandChallenge.Tricks
{
    [AbpAuthorize(PermissionNames.Pages_Tricks)]
    public class TrickAppService :
        AsyncCrudAppService<
            Trick, //The Trick entity
            TrickDto, //Used to show Tricks
            Guid, //Primary key of the Challenge entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateTrickDto>, //Used to create/update a Trick
        ITrickAppService //implement the ITrickAppService
    {
        public TrickAppService(IRepository<Trick, Guid> repository)
            : base(repository)
        {
            //GetPolicyName = BrandChallengePermissions.Tricks.Default;
            //GetListPolicyName = BrandChallengePermissions.Tricks.Default;
            //CreatePolicyName = BrandChallengePermissions.Tricks.Create;
            //UpdatePolicyName = BrandChallengePermissions.Tricks.Edit;
            //DeletePolicyName = BrandChallengePermissions.Tricks.Delete;
        }

        public bool MatchStrings(TrickType type)
        {
            Challenge c = new Challenge();
            if (c.Type.Equals(type))
                return true;
            return false;
        }  
    }
}
