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
    public class StockRepositoryBus
    {
        private StockRepository stockRepository;

        public StockRepositoryBus()
        {
            this.stockRepository = new StockRepository();
        }

        public List<Stock> GetAllStocks()
        {
            return this.stockRepository.GetAllStocks();
        }


        public bool InsertStock(Stock sto)
        {
            int result = 0;
            if (sto != null)
            {
                result = this.stockRepository.InsertStock(sto);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateStock(Stock sto)
        {
            int result = 0;
            if (sto != null)
            {
                result = this.stockRepository.UpdateStock(sto);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteStock(int id)
        {
            int result = this.stockRepository.DeleteStock(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}

