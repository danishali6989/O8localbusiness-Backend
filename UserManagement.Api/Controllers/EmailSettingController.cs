using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Infrastructure.Managers;
using Microsoft.AspNetCore.Authorization;
using UserManagement.Api.Helpers;
using UserManagement.Models.EmailSetting;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSettingController : ControllerBase
    {
        private readonly IEmailSettingManager _manager;
        private readonly IHostingEnvironment _environment;


        public EmailSettingController(IEmailSettingManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Authorize]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] EmailSettingAddModel model)
        {

            
            var header = Request.Headers["CompanyId"];
            try
            {
                await _manager.AddAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("EmailSettings Added");
        }

        [HttpPost]
        [Authorize]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] EmailSettingEditModel model)
        {
            var header = Request.Headers["CompanyId"];
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.EditAsync(model,header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("EmailSetting Updated");
        }

        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var header = Request.Headers["CompanyId"];
            var data = await _manager.GetDetailAsync(id,Convert.ToInt32(header));
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var header = Request.Headers["CompanyId"];

            return Ok(await _manager.GetAllAsync(Convert.ToInt32(header)));
        }


        [HttpPost]
        [Authorize]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var header = Request.Headers["CompanyId"];
            await _manager.DeleteAsync(id, Convert.ToInt32(header));

            return Ok("deleted");
        }
    }
}
