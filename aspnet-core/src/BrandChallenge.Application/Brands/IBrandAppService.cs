using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrandChallenge.Brands
{
    public interface IBrandAppService :
         IAsyncCrudAppService< //Defines CRUD methods
            BrandDto, //Used to show brands
            Guid, //Primary key of the brand entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBrandDto> //Used to create/update a brand
    {

    }
}
