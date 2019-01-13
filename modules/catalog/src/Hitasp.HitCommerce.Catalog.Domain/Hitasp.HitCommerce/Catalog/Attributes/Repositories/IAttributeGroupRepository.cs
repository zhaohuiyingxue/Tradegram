using System;
using Hitasp.HitCommerce.Catalog.Attributes.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public interface IAttributeGroupRepository : IBasicRepository<AttributeGroup, Guid>
    {
        
    }
}