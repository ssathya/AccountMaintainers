using Contracts.Logging;
using Contracts.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AccountOwnerServer.Controllers
{
    //This represents the routing
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        #region Private Fields

        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        #endregion Private Fields

        #region Public Constructors

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

        #endregion Public Constructors

        #region Public Methods

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

        /// <summary>
        /// Gets the owner by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repositoryWrapper.Owner.Find(o => o.Id.Equals(id));
                if (owner == null || owner.Id.Equals(Guid.Empty))
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
                if (owner == null || owner.Id.Equals(Guid.Empty))
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

        #endregion Public Methods
    }
}