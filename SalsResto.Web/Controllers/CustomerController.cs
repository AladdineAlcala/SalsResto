using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using SalsResto.Data;
using SalsResto.Data.Models;
using SalsResto.Data.ViewModel_DTO;
using SalsResto.Web.ActionFilters;

namespace SalsResto.Web.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CustomerController(IRepositoryManager repositoryManager , ILoggerManager logger ,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _repositoryManager.CustomerRepo.GetAllCustomersAsync(trackChanges: false);

                var customerlistdto = _mapper.Map<IEnumerable<CustomerDTOView>>(customers);
                return Ok(customerlistdto);

            }
            catch (Exception e)
            {
                _logger.LogError($"Error from {nameof(GetCustomers)} with error message {e.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}",Name = "CustomerById")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            try
            {
                var customer =await _repositoryManager.CustomerRepo.GetCustomerInfoByIdAsync(id, trackChanges: false);

                var customerdto = _mapper.Map<CustomerDTOView>(customer);

                return Ok(customerdto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error from {nameof(GetCustomers)} with error message {e.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationViewModel customer)
        {
            try
            {
                var customerentity = _mapper.Map<Customer>(customer);
                _repositoryManager.CustomerRepo.CreateCustomer(customerentity);
                 await _repositoryManager.SaveAsync();

                var customerReturn = _mapper.Map<CustomerDTOView>(customerentity);

                return CreatedAtRoute("CustomerById", new { id = customerReturn.Id }, customerReturn);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error from {nameof(CreateCustomer)} with error message {e.Message}");

                return StatusCode(500, "Internal Server Error");
            }

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(Guid id, [FromBody] CustomerForUpdateViewModel customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogError("Customer for update return empty parameter");

                    return BadRequest("Customer Update Object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for the CustomerForCreationDto object");
                    return UnprocessableEntity(ModelState);
                }


                var customerEntity = await _repositoryManager.CustomerRepo.GetCustomerInfoByIdAsync(id, trackChanges: true);

                if (customerEntity == null)
                {
                    _logger.LogInfo($"Customer with customer id {id} does not exist");

                    return NotFound();
                }

                _mapper.Map(customer, customerEntity);
                await  _repositoryManager.SaveAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error from {nameof(UpdateCustomer)} with error message {e.Message}");

                return StatusCode(500, "Internal Server Error");
            }

          
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateCustomer(Guid id,
            [FromBody] JsonPatchDocument<CustomerForUpdateViewModel> patchDocument)
        {
            try
            {
                if (patchDocument == null)
                {
                    _logger.LogError("patchDocument for update return empty parameter");

                    return BadRequest("patchDocument Update Object is null");
                }


                var customerEntity =await _repositoryManager.CustomerRepo.GetCustomerInfoByIdAsync(id, trackChanges: true);

                if (customerEntity == null)
                {
                    _logger.LogInfo($"Customer with customer id {id} does not exist");

                    return NotFound();
                }
                var customerToPatch = _mapper.Map<CustomerForUpdateViewModel>(customerEntity);
                patchDocument.ApplyTo(customerToPatch, ModelState);

                TryValidateModel(customerToPatch);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid model state for the CustomerForCreationDto object");
                    return UnprocessableEntity(ModelState);
                }

               

              

                _mapper.Map(customerToPatch, customerEntity);

                await _repositoryManager.SaveAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error from {nameof(UpdateCustomer)} with error message {e.Message}");

                return StatusCode(500, "Internal Server Error");
            }

           
        }
    }
}
