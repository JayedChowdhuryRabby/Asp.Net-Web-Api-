using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services.Description;

namespace SwiftSaleEcommerce.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/product")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = ProductService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, ProductService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/product/add")]
        public HttpResponseMessage Add(ProductDTO pro)
        {
            try
            {
                var res = ProductService.Add(pro);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = pro });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = pro });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = pro });
            }
        }

        [HttpPost]
        [Route("api/product/update")]
        public HttpResponseMessage Update(ProductDTO pro)
        {
            try
            {
                var res = ProductService.Update(pro);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated", Data = pro });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = pro });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = pro });
            }
        }
        [HttpPost]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ProductService.Delete(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
