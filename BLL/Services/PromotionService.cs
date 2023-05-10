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
    public class PromotionService
    {
        public static bool Create(PromotionDTO Prompt)
        {
            var data = Convert(Prompt);
            return DataAccessFactory.PromotionData().Create(data);

        }
        public static List<PromotionDTO> Read()
        {
            var data = DataAccessFactory.PromotionData().Read();
            return Convert(data);

        }
        public static PromotionDTO Read(int id)
        {
            return Convert(DataAccessFactory.PromotionData().Read(id));
        }

        public static bool Update(PromotionDTO prompt)
        {
            var data = Convert(prompt);
            return DataAccessFactory.PromotionData().Update(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PromotionData().Delete(id);

        }

        static List<PromotionDTO> Convert(List<Promotion> prompt)
        {
            var data = new List<PromotionDTO>();
            foreach (Promotion pro in prompt)
            {
                data.Add(Convert(pro));
            }
            return data;
        }
        static List<Promotion> Convert(List<PromotionDTO> prompt)
        {
            var data = new List<Promotion>();
            foreach (PromotionDTO pro in prompt)
            {
                data.Add(Convert(pro));
            }
            return data;
        }

        static PromotionDTO Convert(Promotion pro)
        {
            return new PromotionDTO()
            {

                prompid = pro.prompid,
                name = pro.name,
                description = pro.description,
                start_date = pro.start_date,
                end_date = pro.end_date,
                discount_amount = pro.discount_amount


            };
        }

        static Promotion Convert(PromotionDTO pro)
        {
            return new Promotion()
            {
                prompid = pro.prompid,
                name = pro.name,
                description = pro.description,
                start_date = pro.start_date,
                end_date = pro.end_date,
                discount_amount = pro.discount_amount

            };

        }
    }
}
