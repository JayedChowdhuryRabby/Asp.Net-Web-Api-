using BLL.DTOs;
using BLL.DTOs.Login;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SwiftSaleEcommerce.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = UserService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/user/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
