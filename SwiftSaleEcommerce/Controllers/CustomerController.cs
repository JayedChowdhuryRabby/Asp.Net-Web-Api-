using BLL.DTOs.Login;
using BLL.DTOs.SignUp;
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
    public class CustomerController : ApiController
    {
        //[CustomerAccess]
        [HttpGet]
        [Route("api/customer")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = CustomerService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/customer/{customer_id}")]
        public HttpResponseMessage Get(int customer_id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, CustomerService.Get(customer_id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/customer/add")]
        public HttpResponseMessage Add(CustomerDTO customerDTO)
        {
            try
            {
                var userDTO = new UserDTO
                {
                    Id = customerDTO.customer_id,
                    Name = customerDTO.first_name,
                    Email = customerDTO.email,
                    Password = customerDTO.password,
                    Role = "Customer"
                };
                var customerAdded = CustomerService.Add(customerDTO);
                var userAdded = UserService.Add(userDTO);

                if (customerAdded && userAdded)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = customerDTO });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = customerDTO });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = customerDTO });
            }
        }
        [HttpPost]
        [Route("api/customer/update")]
        public HttpResponseMessage Update(CustomerDTO customerDTO)
        {
            try
            {
                var res = CustomerService.Update(customerDTO);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "updated", Data = customerDTO });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = customerDTO });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = customerDTO });
            }
        }
        [HttpPost]
        [Route("api/customer/delete/{customer_id}")]
        public HttpResponseMessage Delete(int customer_id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, CustomerService.Delete(customer_id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
