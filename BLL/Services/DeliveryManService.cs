using DAL.Models.SignUp;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.SignUp;

namespace BLL.Services
{
    public class DeliveryManService
    {
        public static bool Create(DeliveryManDTO manageDelivery)
        {
            var data = Convert(manageDelivery);
            return DataAccessFactory.DeliveryManData().Create(data);

        }
        public static List<DeliveryManDTO> Read()
        {
            var data = DataAccessFactory.DeliveryManData().Read();
            return Convert(data);

        }
        public static DeliveryManDTO Read(int id)
        {
            return Convert(DataAccessFactory.DeliveryManData().Read(id));
        }

        public static bool Update(DeliveryManDTO managedelivery)
        {
            var data = Convert(managedelivery);
            return DataAccessFactory.DeliveryManData().Update(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.DeliveryManData().Delete(id);

        }

        static List<DeliveryManDTO> Convert(List<DeliveryMan> Delivery)
        {
            var data = new List<DeliveryManDTO>();
            foreach (DeliveryMan managedelivery in Delivery)
            {
                data.Add(Convert(managedelivery));
            }
            return data;
        }
        static List<DeliveryMan> Convert(List<DeliveryManDTO> Delivery)
        {
            var data = new List<DeliveryMan>();
            foreach (DeliveryManDTO manageDelivery in Delivery)
            {
                data.Add(Convert(manageDelivery));
            }
            return data;
        }

        static DeliveryManDTO Convert(DeliveryMan Delivery)
        {
            return new DeliveryManDTO()
            {

                DelId = Delivery.DelId,
                Name = Delivery.Name,
                Email = Delivery.Email,
                Password = Delivery.Password,
                Phone = Delivery.Phone,
                Gender = Delivery.Gender,
                JoinDate = Delivery.JoinDate,
                Dob = Delivery.Dob,
                Zip_Code = Delivery.Zip_Code,
                nid = Delivery.nid


            };
        }

        static DeliveryMan Convert(DeliveryManDTO del)
        {
            return new DeliveryMan()
            {
                DelId = del.DelId,
                Name = del.Name,
                Email = del.Email,
                Password = del.Password,
                Phone = del.Phone,
                Gender = del.Gender,
                JoinDate = del.JoinDate,
                Dob = del.Dob,
                Zip_Code = del.Zip_Code,
                nid = del.nid
            };

        }
    }
}
