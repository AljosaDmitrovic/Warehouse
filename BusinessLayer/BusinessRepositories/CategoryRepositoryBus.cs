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
    public class CategoryRepositoryBus
    {
        private CategoryRepository categoryRepository;

        public CategoryRepositoryBus()
        {
            this.categoryRepository = new CategoryRepository();
        }

        public List<Category> GetAllCategories()
        {
            return this.categoryRepository.GetAllCategories();
        }
        public string GetCategoryNameById(int id)
        {
            return this.categoryRepository.GetCategoryNameById(id);
        }
        public int GetCategoryIdByName(string name)
        {
            return this.categoryRepository.GetCategoryIdByName(name);
        }
        public Category GetCategoryById(int id)
        {
            return this.categoryRepository.GetCategoryById(id);
        }
        


        public bool InsertCategory(Category cat)
        {
            int result = 0;
            if (cat != null)
            {
                result = this.categoryRepository.InsertCategory(cat);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCategory(Category cat)
        {
            int result = 0;
            if (cat != null)
            {
                result = this.categoryRepository.UpdateCategory(cat);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCategory(int id)
        {
            int result = this.categoryRepository.DeleteCategory(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}

