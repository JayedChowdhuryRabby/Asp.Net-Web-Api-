using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        public static List<CategoryDTO> Get()
        {
            var data = DataAccessFactory.CategoryData().Read();
            return Convert(data);
        }
        public static CategoryDTO Get(int id)
        {
            return Convert(DataAccessFactory.CategoryData().Read(id));
        }
        public static bool Add(CategoryDTO category)
        {
            var data = Convert(category);
            return DataAccessFactory.CategoryData().Create(data);
        }

        public static bool Update(CategoryDTO category)
        {
            var data = Convert(category);
            return DataAccessFactory.CategoryData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CategoryData().Delete(id);
        }

        //convert DTO
        static List<CategoryDTO> Convert(List<Category> categories)
        {
            var data = new List<CategoryDTO>();
            foreach (var item in categories)
            {
                data.Add(new CategoryDTO()
                {
                    Id = item.Id,
                    Category_Name = item.Category_Name

                });
            }
            return data;
        }
        static Category Convert(CategoryDTO categories)
        {
            return new Category()
            {
                Id = categories.Id,
                Category_Name = categories.Category_Name
            };
        }
        static CategoryDTO Convert(Category categories)
        {
            return new CategoryDTO()
            {
                Id = categories.Id,
                Category_Name = categories.Category_Name
            };
        }




        /*public static List<CategoryDTO> Get()
        {
            var data = DataAccessFactory.CategoryData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CategoryDTO>>(data);
            return mapped;
        }
        public static CategoryDTO Get(int id) 
        {
            var data = DataAccessFactory.CategoryData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CategoryDTO>(data);
            return mapped;
        }
        public static bool Add(CategoryDTO category)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(cfg);
            var post = mapper.Map<Category>(category);
            var success = DataAccessFactory.CategoryData().Create(post);
            return success;
        }
         public static bool Update(CategoryDTO category)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(cfg);
            var ctg = mapper.Map<Category>(category);
            var success = DataAccessFactory.CategoryData().Update(ctg);
            return success;
        }*/

    }
}
