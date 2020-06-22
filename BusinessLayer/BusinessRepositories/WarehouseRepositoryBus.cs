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
    public class WarehouseRepositoryBus
    {
        private WarehouseRepository warehouseRepository;

        public WarehouseRepositoryBus()
        {
            this.warehouseRepository = new WarehouseRepository();
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return this.warehouseRepository.GetAllWarehouses();
        }
        public Warehouse GetWarehouseById(int id)
        {
            return this.warehouseRepository.GetWarehouseById(id);
        }
        public int GetWarehouseIdByName(string name)
        {
            return this.warehouseRepository.GetWarehouseIdByName(name);
        }

        public List<Warehouse> GetWarehouseListById(int id)
        {
            return this.warehouseRepository.GetAllWarehouses().Where(war => war.Id == id).ToList();

        }

        public bool InsertWarehouse(Warehouse war)
        {
            int result = 0;
            if (war != null)
            {
                result = this.warehouseRepository.InsertWarehouse(war);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateWarehouse(Warehouse war)
        {
            int result = 0;
            if (war != null)
            {
                result = this.warehouseRepository.UpdateWarehouse(war);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteWarehouse(int id)
        {
            int result = this.warehouseRepository.DeleteWarehouse(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
