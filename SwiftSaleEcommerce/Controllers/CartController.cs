using BLL.DTOs;
using BLL.DTOs.Login;
using BLL.DTOs.SignUp;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwiftSaleEcommerce.Controllers
{
    public class CartController : ApiController
    {
        [HttpGet]
        [Route("api/cart")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = CartService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/cart/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, CartService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/cart/add")]
        public HttpResponseMessage Add(CartDTO ctg)
        {
            try
            {
                var res = CartService.Add(ctg);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = ctg });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = ctg });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = ctg });
            }
        }

        [HttpPost]
        [Route("api/cart/update")]
        public HttpResponseMessage Update(CartDTO ctg)
        {
            try
            {
                var res = CartService.Update(ctg);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated", Data = ctg });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = ctg });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = ctg });
            }
        }
        [HttpPost]
        [Route("api/cart/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, CartService.Delete(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
