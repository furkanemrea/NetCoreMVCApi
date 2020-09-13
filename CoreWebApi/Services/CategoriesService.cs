using CoreWebApi.DataAccess;
using CoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreWebApi.Services
{
   
    public class CategoriesService
    {
        ICategoryDal _categoryDal;
        public CategoriesService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetCategories()
        {
            var result = _categoryDal.GetList();
            return result;
        }

        public Category GetCategoryById(int Id)
        {
            return _categoryDal.Get(x => x.CategoryId == Id);
        }

        public Category AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return category;
        }

        public int DeleteCategory(int Id)
        {
            _categoryDal.Delete(new Category { CategoryId = Id });
            return Id;
        }
    }
}
