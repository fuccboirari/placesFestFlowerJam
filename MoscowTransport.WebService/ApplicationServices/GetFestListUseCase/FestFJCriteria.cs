using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace placesFestFlowerJam.ApplicationServices.GetFestListUseCase
{
    public class FestFJCriteria : ICriteria<Fest>
    {
        public long FestFJId { get; }

        public FestFJCriteria(long festFJId)
            => FestFJId = festFJId;

        public Expression<Func<Fest, bool>> Filter
            => (r => r.Organization.Id == FestFJId);
    }
}
