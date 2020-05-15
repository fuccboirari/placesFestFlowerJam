using placesFestFlowerJam.DomainObjects;
using placesFestFlowerJam.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace placesFestFlowerJam.ApplicationServices.Repositories
{
    public class InMemoryFestRepository : IReadOnlyFestRepository,
                                           IFestRepository 
    {
        private readonly List<Fest> _fests = new List<Fest>();

        public InMemoryFestRepository(IEnumerable<Fest> fests = null)
        {
            if (fests != null)
            {
                _fests.AddRange(fests);
            }
        }

        public Task AddFest(Fest fest)
        {
            _fests.Add(fest);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Fest>> GetAllFests()
        {
            return Task.FromResult(_fests.AsEnumerable());
        }

        public Task<Fest> GetFest(long id)
        {
            return Task.FromResult(_fests.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Fest>> QueryFests(ICriteria<Fest> criteria)
        {
            return Task.FromResult(_fests.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveFest(Fest fest)
        {
            _fests.Remove(fest);
            return Task.CompletedTask;
        }

        public Task UpdateFest(Fest fest)
        {
            var foundFest = GetFest(fest.Id).Result;
            if (foundFest == null)
            {
                AddFest(fest);
            }
            else
            {
                if (foundFest != fest)
                {
                    _fests.Remove(foundFest);
                    _fests.Add(fest);
                }
            }
            return Task.CompletedTask;
        }
    }
}
