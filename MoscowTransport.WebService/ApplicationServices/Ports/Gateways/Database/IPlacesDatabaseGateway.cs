using placesFestFlowerJam.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace placesFestFlowerJam.ApplicationServices.Ports.Gateways.Database
{
    public interface IPlacesDatabaseGateway
    {
        Task AddFest(Fest fest);

        Task RemoveFest(Fest fest);

        Task UpdateFest(Fest fest);

        Task<Fest> GetFest(long id);

        Task<IEnumerable<Fest>> GetAllFests();

        Task<IEnumerable<Fest>> QueryFests(Expression<Func<Fest, bool>> filter);


        Task AddFestFJ(FestFJ festFJ);

        Task UpdateFestFJ(FestFJ festFJ);

        Task RemoveFestFJ(FestFJ festFJ);

        Task<FestFJ> GetFestFJ(long id);

        Task<IEnumerable<FestFJ>> GetAllFestFJ();

        Task<IEnumerable<FestFJ>> QueryFestsFJ(Expression<Func<FestsFJ, bool>> filter);
    }
}
