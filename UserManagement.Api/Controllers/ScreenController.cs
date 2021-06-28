using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Api.Helpers;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.Screen;
using UserManagement.Utilities;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        private readonly I1ScreenManager _manager;
        private readonly IHostingEnvironment _environment;

        public ScreenController(I1ScreenManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }
        [HttpPost]
        [Authorize]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] ScreenAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.AddAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Screen Created");
        }
        [HttpPost]
        [Authorize]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] ScreenEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.EditAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Screen Updated");
        }
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var data = await _manager.GetDetailAsync(id);
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
            return Ok(await _manager.GetAllAsync());
        }

        [HttpPost]
        [Authorize]
        [Route("paged-result")]
        public async Task<IActionResult> PagedResult(JqDataTableRequest model)
        {
            return Ok(await _manager.GetPagedResultAsync(model));
        }
        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);

            return Ok("deleted");
        }
    }
}
