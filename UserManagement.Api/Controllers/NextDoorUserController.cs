using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Api.Helpers;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.NextDoorUser;

namespace UserManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NextDoorUserController : ControllerBase
    {
        private readonly INextDoorUserManager _manager;
        private readonly IHostingEnvironment _environment;

        public NextDoorUserController(INextDoorUserManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
      //  [Authorize]
        [Route("SignUpNextDoorUser")]
        public async Task<IActionResult> Add([FromBody] AddNextDoorUserModel model)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }


            if (await _manager.CheckNextDoorUserEmail(model.Email) != null)
            {
                return BadRequest("Email Already SS Exist");
            }

            try
            {  

                await _manager.AddAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("NextDoorUser Created");

        }



        [HttpPost]
      //  [Authorize]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           

            await _manager.DeleteAsync(id);

            return Ok("Deleted");
        }
        [HttpGet]
       // [Authorize]
       // [AllowAnonymous]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            

            return Ok(await _manager.GetAllAsync());
        }



        [HttpPost]
        [Route("CheckNextDoorUser")]
        public async Task<IActionResult> CheckNextDoorUser(CheckNextDoorUser model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorList());
                }
                var data = await _manager.CheckUser(model.email);
                if (data != null)
                {
                   
                        if (UserManagement.Utilities.Utility.Decrypt(model.password, data.Password) == false)
                        {
                            return BadRequest("Invalid Password");
                        }
                        else
                        {
                            return Ok("valid User");
                        }
                            
                        
                    
                }
                else
                {
                    return BadRequest("Invalid UserName");
                }


            }

            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
