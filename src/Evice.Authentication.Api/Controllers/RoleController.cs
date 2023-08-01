using Evice.Authentication.Application.Commands.Requests.Role;
using Evice.Authentication.Application.Handlers.Interfaces;
using Evice.Authentication.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Evice.Authentication.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleHandler _roleHandler;
        private readonly IRoleQuery _roleQuery;

        public RoleController(IRoleHandler roleHandler, IRoleQuery roleQuery)
        {
            this._roleHandler = roleHandler ?? throw new ArgumentNullException(nameof(roleHandler));
            this._roleQuery = roleQuery ?? throw new ArgumentNullException(nameof(roleQuery));
        }
 
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] RoleRequest request)
        {
            var response = await this._roleHandler.Add(request);

            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] RoleRequest request)
        {
            var response = await this._roleHandler.Update(request);

            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Guid roleId)
        {
            var response = await this._roleHandler.Delete(roleId);

            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost("getById")]
        public async Task<IActionResult> Get([FromBody] string roleId)
        {
            var response = await this._roleQuery.GetById(roleId);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}