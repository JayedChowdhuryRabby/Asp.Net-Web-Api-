using BLL.DTOs.Login;
using BLL.DTOs;
using BLL.Services;
using SwiftSaleEcommerce.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs.SignUp;
using System.Web.Http.Cors;

namespace SwiftSaleEcommerce.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = AdminService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/admin/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, AdminService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/admin/add")]
        public HttpResponseMessage Add(AdminDTO adminDTO)
        {
            try
            {
                var userDTO = new UserDTO
                {
                    Id = adminDTO.Id,
                    Name = adminDTO.Name,
                    Email = adminDTO.Email,
                    Password = adminDTO.Password,
                    Role = "Admin"
                };
                var adminAdded = AdminService.Add(adminDTO);
                var userAdded = UserService.Add(userDTO);

                if (adminAdded && userAdded)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = adminDTO });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = adminDTO });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = adminDTO });
            }
        }

        [HttpPost]
        [Route("api/admin/update")]
        public HttpResponseMessage Update(AdminDTO adminDTO)
        {
            try
            {
                var res = AdminService.Update(adminDTO);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated", Data = adminDTO });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = adminDTO });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = adminDTO });
            }
        }
        [HttpPost]
        [Route("api/admin/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, AdminService.Delete(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
