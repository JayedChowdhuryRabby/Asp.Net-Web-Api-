using BLL.DTOs;
using BLL.DTOs.Login;
using BLL.Services;
using SwiftSaleEcommerce.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SwiftSaleEcommerce.Controllers
{
    public class SellerController : ApiController
    {
        [SellerAccess]
        [HttpGet]
        [Route("api/seller")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = SellerService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/seller/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, SellerService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/seller/add")]
        public HttpResponseMessage Add(SellerDTO sellerDTO)
        {
            try
            {
                var userDTO = new UserDTO
                {
                    Id = sellerDTO.Id,
                    Name = sellerDTO.Seller_Name,
                    Email = sellerDTO.Seller_Email,
                    Password = sellerDTO.Seller_Password,
                    Role = "Seller" 
                };
                var sellerAdded = SellerService.Add(sellerDTO);
                var userAdded = UserService.Add(userDTO);

                if (sellerAdded && userAdded)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = sellerDTO });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = sellerDTO });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = sellerDTO });
            }
        }
        
        [HttpPost]
        [Route("api/seller/update")]
        public HttpResponseMessage Update(SellerDTO sellerDTO)
        {
            try
            {
                var res = SellerService.Update(sellerDTO);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated", Data = sellerDTO });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = sellerDTO });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = sellerDTO });
            }
        }
        [HttpPost]
        [Route("api/seller/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, SellerService.Delete(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
