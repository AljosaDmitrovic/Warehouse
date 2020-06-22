using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.DataRepositories;
using DataLayer.Models;

namespace BusinessLayer
{
    public class LocationRepositoryBus
    {
        private LocationRepository locationRepository;

        public LocationRepositoryBus()
        {
            this.locationRepository = new LocationRepository();
        }

        public List<Location> GetAllLocations()
        {
            return this.locationRepository.GetAllLocations();
        }

        public Location GetLocationById(int id)
        {
            return this.locationRepository.GetLocationById(id);
        }

        public int GetLocationIdByName(String locName)
        {
            return this.locationRepository.GetLocationIdByName(locName);
        }

        
        public String GetLocationNameById(int id)
        {
            return this.locationRepository.GetLocationNameById(id);
        }
        


        /* INSERT , UPDATE, DELETE*/
        public bool InsertLocation(Location loc)
        {
            int result = 0;
            if (loc != null)
            {
                result = this.locationRepository.InsertLocation(loc);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateLocation(Location loc)
        {
            int result = 0;
            if (loc != null)
            {
                result = this.locationRepository.UpdateLocation(loc);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteLocation(int id)
        {
            int result = this.locationRepository.DeleteLocation(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}

