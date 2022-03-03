using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalsResto.Data;
using SalsResto.Data.Models;

namespace SalsResto.Web.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        public CustomerController(IRepositoryManager repositoryManager , ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = _repositoryManager.CustomerRepo.GetAllCustomers(trackChanges: false);
                return Ok(customers);

            }
            catch (Exception e)
            {
                _logger.LogError($"Error from {nameof(GetCustomers)} with error message {e.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
