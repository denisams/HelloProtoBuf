using Microsoft.AspNetCore.Mvc;
using PhoneChipSales.Core.Services;
using System.Text.Json;

namespace PhoneChipSales.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        [HttpPost("serialize")]
        public IActionResult SerializeCustomer(Customer customer)
        {
            var protobufData = _customerService.SerializeCustomer(customer);
            return Ok(protobufData);
        }

        [HttpPost("deserialize")]
        public IActionResult DeserializeCustomer([FromBody] byte[] data)
        {
            var customer = _customerService.DeserializeCustomer(data);
            return Ok(customer);
        }

        [HttpPost("serializeToJson")]
        public IActionResult SerializeCustomerToJson(Customer customer)
        {
            var jsonData = JsonSerializer.Serialize(customer);
            return Ok(jsonData);
        }

        [HttpPost("deserializeFromJson")]
        public IActionResult DeserializeCustomerFromJson([FromBody] JsonElement jsonElement)
        {
            var jsonData = jsonElement.GetRawText();
            var customer = JsonSerializer.Deserialize<Customer>(jsonData);
            return Ok(customer);
        }
    }
}
