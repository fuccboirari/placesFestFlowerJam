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
    public class InMemoryFestFJRepository : IReadOnlyFestFJRepository,
                                                           IFestFJRepository
    {
        private readonly List<FestFJ> _festFJ = new List<FestFJ>();

        public InMemoryFestFJRepository(IEnumerable<FestsFJ> festsFJ)
        {
            if (festsFJ != null)
            {
                _festsFJ.AddRange(festsFJ);
            }
        }

        public Task AddFestFJ(FestFJ festFJ)
        {
            _festsFJ.Add(festFJ);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<FestFJ>> GetAllFestsFJ()
        {
            return Task.FromResult(_festsFJ.AsEnumerable());
        }

        public Task<FestFJ> GetFestFJ(long id)
        {
            return Task.FromResult(_festsFJ.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<FestFJ>> QueryFestFJ(ICriteria<FestFJ> criteria)
        {
            return Task.FromResult(_festsFJ.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveFestFJ(FestFJ festFJ)
        {
            _festsFJ.Remove(festFJ);
            return Task.CompletedTask;
        }

        public Task UpdateFestFJ(FestFJ festFJ)
        {
            var foundFestFJ = GetFestFJ(festFJ.Id).Result;
            if (foundFestFJ == null)
            {
                AddFestFJ(festFJ);
            }
            else
            {
                if (foundFestFJ != festFJ)
                {
                    _festsFJ.Remove(foundFestFJ);
                    _festsFJ.Add(festFJ);
                }
            }
            return Task.CompletedTask;
        }
    }
}
