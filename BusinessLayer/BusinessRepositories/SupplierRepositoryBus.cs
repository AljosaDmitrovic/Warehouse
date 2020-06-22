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
    public class SupplierRepositoryBus
    {
        private SupplierRepository supplierRepository;

        public SupplierRepositoryBus()
        {
            this.supplierRepository = new SupplierRepository();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return this.supplierRepository.GetAllSuppliers();
        }
        public Supplier GetSupplierById(int id)
        {
            return this.supplierRepository.GetSupplierById(id);
        }
        public string GetSupplierNameById(int id)
        {
            return this.supplierRepository.GetSupplierNameById(id);
        }
        public int GetSupplierIdByName(string name)
        {
            return this.supplierRepository.GetSupplierIdByName(name);
        }

        public bool InsertSupplier(Supplier sup)
        {
            int result = 0;
            if (sup != null)
            {
                result = this.supplierRepository.InsertSupplier(sup);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSupplier(Supplier sup)
        {
            int result = 0;
            if (sup != null)
            {
                result = this.supplierRepository.UpdateSupplier(sup);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteSupplier(int id)
        {
            int result = this.supplierRepository.DeleteSupplier(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
