using placesFestFlowerJam.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using placesFestFlowerJam.ApplicationServices.Ports.Gateways.Database;

namespace placesFestFlowerJam.InfrastructureServices.Gateways.Database
{
    public class PlacesEFSqliteGateway : IPlacesDatabaseGateway
    {
        private readonly PlacesContext _placesContext;

        public PlacesEFSqliteGateway(PlacesContext placesContext)
            => _placesContext = placesContext;

        public async Task<Fest> GetFest(long id)
           => await _placesContext.Routes.Include(r => r.Organization).Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Fest>> GetAllFests()
            => await _placesContext.Routes.Include(r => r.Organization).ToListAsync();
          
        public async Task<IEnumerable<Fest>> QueryFests(Expression<Func<Fest, bool>> filter)
            => await _placesContext.Routes.Include(r => r.Organization).Where(filter).ToListAsync();

        public async Task AddFest(Fest fest)
        {
            _placesContext.Fest.Add(fest);
            await _placesContext.SaveChangesAsync();
        }

        public async Task UpdateFest(Fest fest)
        {
            _placesContext.Entry(fest).State = EntityState.Modified;
            await _placesContext.SaveChangesAsync();
        }

        public async Task RemoveFest(Fest fest)
        {
            _placesContext.Fests.Remove(fest);
            await _placesContext.SaveChangesAsync();
        }


        public async Task<FestFJ> GetFestFJ(long id)
            => await _placesContext.FestsFJ.Where(to => to.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<FestFJ>> GetAllFestFJ()
            => await _placesContext.FestFJ.ToListAsync();

        public async Task<IEnumerable<FestFJ>> QueryFestFJ(Expression<Func<FestFJ, bool>> filter)
            => await _placesContext.FestFJ.Where(filter).ToListAsync();

        public async Task AddFestFJ(FestFJ festFJ)
        {
            _placesContext.TransportOrganizations.Add(festFJ);
            await _placesContext.SaveChangesAsync();
        }

        public async Task UpdateTransportOrganization(FestFJ festFJ)
        {
            _placesContext.Entry(festFJ).State = EntityState.Modified;
            await _placesContext.SaveChangesAsync();
        }

        public async Task RemoveFestFJ(FestFJ festFj)
        {
            _placesContext.TransportOrganizations.Remove(festFj);
            await _placesContext.SaveChangesAsync();
        }
    }
}
