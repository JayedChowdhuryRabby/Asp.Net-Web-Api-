using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class SearchService
    {
        public static bool Create(SearchDTO search)
        {
            var data = Convert(search);
            return DataAccessFactory.SearchData().Create(data);

        }
        public static List<SearchDTO> Read()
        {
            var data = DataAccessFactory.SearchData().Read();
            return Convert(data);

        }
        public static SearchDTO Read(int id)
        {
            return Convert(DataAccessFactory.SearchData().Read(id));
        }

        public static bool Update(SearchDTO search)
        {
            var data = Convert(search);
            return DataAccessFactory.SearchData().Update(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.SearchData().Delete(id);

        }

        static List<SearchDTO> Convert(List<Search> search)
        {
            var data = new List<SearchDTO>();
            foreach (Search sea in search)
            {
                data.Add(Convert(sea));
            }
            return data;
        }
        static List<Search> Convert(List<SearchDTO> search)
        {
            var data = new List<Search>();
            foreach (SearchDTO sea in search)
            {
                data.Add(Convert(sea));
            }
            return data;
        }

        static SearchDTO Convert(Search search)
        {
            return new SearchDTO()
            {

                search_Id = search.search_Id,
                cust_id = search.cust_id,
                search_text = search.search_text


            };
        }

        static Search Convert(SearchDTO search)
        {
            return new Search()
            {
                search_Id = search.search_Id,
                cust_id = search.cust_id,
                search_text = search.search_text


            };

        }
    }
}
