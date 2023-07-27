using Evice.Authentication.Application.Commands.Requests.Company;
using Evice.Authentication.Application.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Evice.Authentication.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyHandler _companyHandler;

        public CompanyController(ICompanyHandler companyHandler)
            => this._companyHandler = companyHandler ?? throw new ArgumentNullException(nameof(companyHandler));

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddCompanyRequest request)
        {
            var response = await this._companyHandler.Add(request);

            return StatusCode((int)response.HttpStatusCode, response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyRequest request)
        {
            var response = await this._companyHandler.Update(request);

            return StatusCode((int)response.HttpStatusCode, response);
        }
    }
}