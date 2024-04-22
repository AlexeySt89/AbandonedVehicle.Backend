using AbandonedVehicle.Application.Vehicles.Commands.CreateVehicle;
using AbandonedVehicle.Application.Vehicles.Commands.DeleteVehicle;
using AbandonedVehicle.Application.Vehicles.Commands.UpdateVehicle;
using AbandonedVehicle.Application.Vehicles.Queries.GetVahicleDetails;
using AbandonedVehicle.Application.Vehicles.Queries.GetVehicleList;
using AbandonedVehicle.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbandonedVehicle.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VehicleController : BaseController
    {
        private readonly IMapper _mapper;

        public VehicleController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of vehicle
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /vehicle
        /// </remarks>
        /// <returns>Returns VehicleListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unautorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<VehicleListVm>> GetAll()
        {
            var query = new GetVehicleListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the vehicle by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /vehicle/2AC2E0C3-B73D-47AD-AD46-08000DAEBE41
        /// </remarks>
        /// <param name="id">Vehicle id (guid)</param>
        /// <returns>Returns VehicleDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unautorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<VehicleListVm>> Get(Guid id)
        {
            var query = new GetVehicleDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the vehicle
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /vehicle 
        /// {
        ///     address: "vehicle address",
        ///     description: "vehicle description"
        /// }
        /// </remarks>
        /// <param name="createVehicleDto">CreateVehicleDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unautorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateVehicleDto createVehicleDto)
        {
            var command = _mapper.Map<CreateVehicleCommand>(createVehicleDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Updates the vehicle
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /vehicle 
        /// {
        ///     address: "vehicle address"
        /// }
        /// </remarks>
        /// <param name="updateVehicleDto">UpdateVehicleDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unautorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleDto updateVehicleDto)
        {
            var command = _mapper.Map<UpdateVehicleCommand>(updateVehicleDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the vehicle by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /vehicle/2AC2E0C3-B73D-47AD-AD46-08000DAEBE41
        /// </remarks>
        /// <param name="id">Id of the vehicle (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unautorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteVehicleCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
