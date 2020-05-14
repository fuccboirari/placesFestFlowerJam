using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace placesFestFlowerJam.DomainObjects.Ports
{
    public interface IReadOnlyFestRepository
    {
        Task<Fest> GetFest (long id);

        Task<IEnumerable<Fest>> GetAllFests();

        Task<IEnumerable<Fest>> QueryFests(ICriteria<Fest> criteria);

    }

    public interface IFestRepository
    {
        Task AddFest(Fest fest);

        Task RemoveFest(Fest fest);

        Task UpdateFest(Fest fest);
    }
}
