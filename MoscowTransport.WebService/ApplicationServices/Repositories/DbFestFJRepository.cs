using placesFestFlowerJam.ApplicationServices.Ports.Gateways.Database;
using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace placesFestFlowerJam.ApplicationServices.Repositories
{
    public class DbFestFJRepository : IReadOnlyFestFJRepository,
                                                     IFestFJRepository
    {
        private readonly IPlacesDatabaseGateway _databaseGateway;

        public DbFestFJRepository(IPlacesDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<FestFJ> GetFestFJ(long id)
            => await _databaseGateway.GetFestFJ(id);

        public async Task<IEnumerable<FestFj>> GetAllFestsFJ()
            => await _databaseGateway.GetAllFestFJ();

        public async Task<IEnumerable<FestFJ>> QueryFestsFJ(ICriteria<FestFJ> criteria)
            => await _databaseGateway.QueryTransportOrganizations(criteria.Filter);

        public async Task AddFestFJ(FestFJ festFJ)
            => await _databaseGateway.AddFestFJ(festFJ);

        public async Task UpdateFestFJ(FestFJ festFJ)
            => await _databaseGateway.UpdateFestFJ(festFJ);

        public async Task RemoveFestFJ(FestFJ festFJ)
            => await _databaseGateway.RemoveFestFJ(festFJ);
    }
}
