using Beneyetna.BLL;
using Beneyetna.BLL.IServices;
using Beneyetna.DAL;
using Beneyetna.DataContracts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Beneyetna.DataContracts.DTO;

namespace Beneyetna.API.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        BLLFacade _bLLFacade;

        public RegisterController(IConfiguration configuration, BLLFacade bLLFacade)
        {
            _configuration = configuration;
            _bLLFacade = bLLFacade;

        }

        [HttpPost("RegisterByEmail")]
        public async Task<IActionResult> RegisterByEmailAsync([FromBody] RegisterDTO registerDTO, [FromHeader] string authenticationStr)
        {
            ApiResponse response = await _bLLFacade._registerService.RegisterByEmail(registerDTO, authenticationStr);
            return StatusCode(response.Code, response);
        }

    }
}

