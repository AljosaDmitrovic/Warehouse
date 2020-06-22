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
    public class ProductRepositoryBus
    {
        private ProductRepository productRepository;

        public ProductRepositoryBus()
        {
            this.productRepository = new ProductRepository();
        }

        public List<Product> GetAllProducts()
        {
            return this.productRepository.GetAllProducts();
        }
        public Product GetProductById(int id)
        {
            return this.productRepository.GetProductById(id);
        }
        public int GetProductIdByName(string name)
        {
            return this.productRepository.GetProductIdByName(name);
        }
        

        public Product GetProductByName(string name)
        {
            return this.productRepository.GetProductByName(name);
        }
        public bool InsertProduct(Product pro)
        {
            int result = 0;
            if (pro != null)
            {
                result = this.productRepository.InsertProduct(pro);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Product pro)
        {
            int result = 0;
            if (pro != null)
            {
                result = this.productRepository.UpdateProduct(pro);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            int result = this.productRepository.DeleteProduct(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}

