﻿using Hitasp.HitCommon.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Media
{
    public class MongoPictureRepository : MongoMediaRepository<Picture>, IPictureRepository
    {
        public MongoPictureRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
