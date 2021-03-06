using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Directions
{
    public class EfCoreStateOrProvinceRepository : EfCoreRepository<HitCommerceDbContext, StateOrProvince, Guid>,
        IStateOrProvinceRepository
    {
        public EfCoreStateOrProvinceRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<StateOrProvince>> ListByCountryId(Guid countryId)
        {
            return await DbSet.Where(x => x.CountryId == countryId).ToListAsync();
        }

        public async Task<StateOrProvince> FindByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync( x => x.Name == name);
        }
    }
}