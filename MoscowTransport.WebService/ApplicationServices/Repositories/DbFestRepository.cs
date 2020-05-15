using placesFestFlowerJam.ApplicationServices.Ports.Gateways.Database;
using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace placesFestFlowerJam.ApplicationServices.Repositories
{
    public class DbFestRepository : IReadOnlyFestRepository,
                                     IFestRepository
    {
        private readonly IPlacesDatabaseGateway _databaseGateway;

        public DbFestRepository(IPlacesDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<Fest> GetFest(long id)
            => await _databaseGateway.GetFest(id);

        public async Task<IEnumerable<Fest>> GetAllFests()
            => await _databaseGateway.GetAllFests();

        public async Task<IEnumerable<Fest>> QueryFests(ICriteria<Fest> criteria)
            => await _databaseGateway.QueryFests(criteria.Filter);

        public async Task AddFest(Fest fest)
            => await _databaseGateway.AddFest(fest);

        public async Task RemoveFest(Fest fest)
            => await _databaseGateway.RemoveFest(fest);

        public async Task UpdateFest(Fest fest)
            => await _databaseGateway.UpdateFest(fest);
    }
}
