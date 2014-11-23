using Fluentvalidation.WebApiDemo.Models;
using System.Web;
using System.Web.Http;

namespace Fluentvalidation.WebApiDemo.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        [Route("{customerId:min(0)}")]
        public Customer Get(int customerId)
        {
            return new Customer()
            {
                Id = customerId,
                LastName = "Olav",
                FirstName = "Nybø",
                HouseNumber = "1",
                Street = "Arbeidersamfunnets plass",
                City = "Oslo",
                ZipCode = "0181"
            };
        }

        [Route("")]
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Created(Request.RequestUri + customer.Id.ToString(), customer);
        }
    }
}