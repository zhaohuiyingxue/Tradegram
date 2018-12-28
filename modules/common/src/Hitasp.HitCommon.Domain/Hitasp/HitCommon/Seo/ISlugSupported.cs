using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public interface ISlugSupported : IAggregateRoot<Guid>
    {
        string Name { get; }

        string Slug  { get; }
    }
}