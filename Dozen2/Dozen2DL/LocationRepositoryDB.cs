using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class LocationRepositoryDB : ILocationRepository
    {
        private DrinkDBContext _context;
      

        public LocationRepositoryDB(DrinkDBContext context)
        {
            _context = context;
        
        }

        public List<Location> GetLocations()
        {
            
            return _context.Locations.OrderBy(i => i.LocationName).ToList();
        }

        public Location GetSpecifiedLocation(int locationID)
        {
            return _context.Locations.Where(i => i.LocationID == locationID).FirstOrDefault();
        }
    }
}
