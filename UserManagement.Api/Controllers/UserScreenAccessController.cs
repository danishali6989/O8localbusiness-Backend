using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.UserAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UserManagement.Models.EmailSetting;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserScreenAccessController : ControllerBase
    {
        private readonly IUserAccessMAnager _manager;
       
        private readonly IHostingEnvironment _environment;

        public UserScreenAccessController( IUserAccessMAnager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        
        }


        [HttpPost]
      [Authorize]
        [Route("AddScreenAccess")]
        public async Task<IActionResult> AddScreenAcess(ScreenAccessModel model)
        {
            var header = Request.Headers["CompanyId"];

            try
            {
                await _manager.AddUserScreenAccessAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Created");
        }


        [HttpGet]
       [Authorize]
        [Route("getScreenAccessByUserRoleId/{id}")]
        public async Task<IActionResult> GetScreenAccessByUserRoleId(int id)
        {
            var header = Request.Headers["CompanyId"];

            return Ok(await _manager.GetUserScreenAccessById(id, Convert.ToInt32(header)));
        }
        [HttpGet]
        [Authorize]
        [Route("getAllScreens")]
        public async Task<IActionResult> GetAllScreenDetail()
        {
            var header = Request.Headers["CompanyId"];

            return Ok(await _manager.GetAllScreenDetail(Convert.ToInt32(header)));
        }



        
    }
}
