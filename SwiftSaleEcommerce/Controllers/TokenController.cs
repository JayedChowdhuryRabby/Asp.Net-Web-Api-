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
    [EnableCors("*","*","*")]
    public class TokenController : ApiController
    {
        [HttpGet]
        [Route("api/token")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = TokenService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
