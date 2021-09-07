using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.RolePermission;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermiController : ControllerBase
    {

        private readonly IRolePermiManager _manager;
        private readonly IHostingEnvironment _environment;


        public RolePermiController(IRolePermiManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        //  [Authorize]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] List<AddRolePermission> model)
        {
            var header = Request.Headers["CompanyId"];
            /* if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState.GetErrorList());
             }*/

            try
            {
                foreach(var item in model)
                { 
                    if(item.CanCheck == true)
                    {
                        var data1 = _manager.isExist(item);
                        if (data1 == null)
                        {
                            await _manager.AddAsync(item, header.ToString());
                        }
                    }
                    else
                    {
                      var  data1 = _manager.isExist(item);
                        if(data1!=null)
                        {
                          await _manager.DeleteAsync2(data1.Id);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("RolePermission Added");
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
    }
}
