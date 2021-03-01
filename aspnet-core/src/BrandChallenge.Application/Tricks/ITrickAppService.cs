using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrandChallenge.Tricks
{
    public interface ITrickAppService :
        IAsyncCrudAppService< //Defines CRUD methods
            TrickDto, //Used to show tricks
            Guid, //Primary key of the trick entity        
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateTrickDto> //Used to create/update a trick
    {
        public bool MatchStrings(TrickType type);
       
    }
}
