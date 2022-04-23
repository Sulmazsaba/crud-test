using Mc2.CrudTest.Application.Customer;
using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Commands;
using Mc2.CrudTest.Domain.CustomerModule.Queries;
using Mc2.CrudTest.Presentation.Server.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerWriter _customerWriter;
        private readonly ICustomerReader _customerReader;

        public CustomersController(ICustomerWriter customerWriter, ICustomerReader customerReader)
        {
            _customerWriter = customerWriter;
            _customerReader = customerReader;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(AddCustomerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerToReturn = await _customerWriter.AddCustomer(command);
            return CreatedAtRoute("GetCustomer", new { customerId = customerToReturn.Id }, customerToReturn);

        }


        [HttpPut("{customerId}", Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCustomer(Guid customerId, UpdateCustomerRequest request)
        {
            await _customerWriter.UpdateCustomer(request.ToUpdateCustomerCommand(customerId));
            return NoContent();
        }

        [HttpDelete("{customerId}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCustomer(Guid customerId)
        {
            var deleteCommand = new DeleteCustomerCommand { Id = customerId };
            await _customerWriter.DeleteCustomer(deleteCommand);
            return NoContent();
        }


        [HttpGet("{customerId}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerDto>> GetCustomer(Guid customerId)
        {
            var command = new GetCustomerByIdQuery { Id = customerId };
            var result = await _customerReader.GetById(command);
            return Ok(result);
        }


        [HttpGet(Name = "GetCustomers")]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var result = await _customerReader.GetAll();
            return Ok(result);
        }


    }
}
