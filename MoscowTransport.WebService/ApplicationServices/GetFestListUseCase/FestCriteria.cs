using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace placesFestFlowerJam.ApplicationServices.GetFestListUseCase
{
    public class FestCriteria : ICriteria <Fest>
    {
        public long FestId { get; }

        public FestCriteria(long festId)
            => FestId = festId;

        public Expression<Func<Fest, bool>> Filter
            => (r => r.FestId.Id == FestId);
    }
}
