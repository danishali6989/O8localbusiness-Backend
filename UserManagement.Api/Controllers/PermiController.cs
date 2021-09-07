using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Api.Helpers;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.Permission;

namespace UserManagement.Api.Controllers
{
    
    

        [Route("api/[controller]")]
        [ApiController]
        public class PermiController : ControllerBase
        {
            private readonly IPermiManager _manager;
            private readonly IHostingEnvironment _environment;


            public PermiController(IPermiManager manager,
                IHostingEnvironment environment)
            {
                _manager = manager;
                _environment = environment;
            }

            [HttpPost]
          //  [Authorize]
            [Route("add")]
            public async Task<IActionResult> Add([FromBody] PermissionAddModel model)
            {
                var header = Request.Headers["CompanyId"];
                /* if (!ModelState.IsValid)
                 {
                     return BadRequest(ModelState.GetErrorList());
                 }*/

                try
                {
                    await _manager.AddAsync(model, header.ToString());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok("Permission Added");
            }

        [HttpPost]
        //[Authorize]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] PermissionEditModel model)
        {
            var header = Request.Headers["CompanyId"];
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.EditAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Permission Updated");
        }

        [HttpGet]
        //[Authorize]
        [AllowAnonymous]
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var header = Request.Headers["CompanyId"];

            var data = await _manager.GetDetailAsync(id, Convert.ToInt32(header));
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("get-detail-By-ScreenId/{id}")]
        public async Task<IActionResult> GetDetailByScreenId(int id)
        {
            var header = Request.Headers["CompanyId"];
            try
            {
              var data = await _manager.GetDetailByScreenAsync(id, Convert.ToInt32(header));
                if (data == null)
                {
                    return NotFound();
                }
             return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpPost]
        //  [Authorize]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var header = Request.Headers["CompanyId"];

            await _manager.DeleteAsync(id, Convert.ToInt32(header));

            return Ok("Deleted");
        }

        [HttpGet]
        // [Authorize]
        [AllowAnonymous]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var header = Request.Headers["CompanyId"];

            return Ok(await _manager.GetAllAsync(Convert.ToInt32(header)));
        }

    }

}
