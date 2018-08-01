using Contracts.Logging;
using Contracts.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Entities.Extensions;
using Entities.Models;

namespace AccountOwnerServer.Controllers
{
    //This represents the routing
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repositoryWrapper">The repository wrapper.</param>
        public OwnerController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// Gets all owners.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repositoryWrapper.Owner.GetAllOwners();
                _logger.LogInfo($"Returned {owners.Count()} owners from database");
                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repositoryWrapper.Owner.Find(o => o.Id.Equals(id));
                if (owner == null || owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, was not found in database");
                    return NotFound();
                }
                _logger.LogInfo($"Returning owner with id: {id}");
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the owner wit details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWitDetails(Guid id)
        {
            try
            {
                var owner = _repositoryWrapper.Owner.GetOwnerWithDetails(id);
                if (owner == null || owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id} not found in database");
                    return NotFound();
                }
                _logger.LogInfo($"Returning owner with id: {id}");
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error"); ;
            }
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] Owner owner)
        {
            if (owner.IsObjectNull())
            {
                _logger.LogError("Owner object sent from client is null");
                return BadRequest("Owner object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client");
                return BadRequest("Invalid model object");
            }
            try
            {
                _repositoryWrapper.Owner.CreateOwner(owner);
                return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if (owner.IsObjectNull())
            {
                _logger.LogError("Owner object sent from client is null");
                return BadRequest("Owner object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client");
                return BadRequest("Invalid model object");
            }

            try
            {
                var dbOwner = _repositoryWrapper.Owner.GetOwnerById(id);
                if (dbOwner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id},  not found in database");
                    return NotFound();
                }
                _repositoryWrapper.Owner.UpdateOwner(dbOwner, owner);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}