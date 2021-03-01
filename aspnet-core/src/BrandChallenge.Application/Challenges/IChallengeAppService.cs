using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrandChallenge.Challenges
{
    public interface IChallengeAppService :
        IAsyncCrudAppService< //Defines CRUD methods
            ChallengeDto, //Used to show challenges
            Guid, //Primary key of the challenge entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateChallengeDto> //Used to create/update a challenge
    {
    }
}
