using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Api.Helpers;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.Field;
using UserManagement.Utilities;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldManager _manager;
        private readonly IHostingEnvironment _environment;


        public FieldController(IFieldManager manager,
           IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Authorize]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] FieldsAddModel model)
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

            return Ok("Field Added");
        }

        [HttpPost]
        [Authorize]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] FieldEditModel model)
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

            return Ok("Language Updated");
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
        [Route("get-Field-detail")]
        public async Task<IActionResult> GetFieldDetail(int lang_id,int screen_id)
        {
             await _manager.GetFieldDetailAsync(lang_id,screen_id);
            return Ok(  await _manager.GetFieldDetailAsync(lang_id,screen_id));
            
           /* if (data == null)
            {
                return NotFound();
            }*/
           // return Ok(data);
        }

        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [Route("get-Field-detail-By-Language")]
        public async Task<IActionResult> GetFieldDetailByLanguage(int lang_id)
        {

            return Ok(await _manager.GetFieldDetailByLanguageAsync(lang_id));
            /* if (data == null)
             {
                 return NotFound();
             }*/
            // return Ok(data);
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
        [Authorize]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            await _manager.DeleteAsync(id);

            return Ok("deleted");
        }
    }
}

