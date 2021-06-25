using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Helpers;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.UserLogin;
using UserManagement.Models.User;

using UserManagement.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IO;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager _manager;
        private readonly IHostingEnvironment _environment;
        private readonly IHostingEnvironment _hostingEnv;

        public UserController(IHostingEnvironment hostingEnv, IConfiguration configuration, IUserManager manager,
            IHostingEnvironment environment)
        {
            _configuration = configuration;
            _manager = manager;
            _environment = environment;
             _hostingEnv = hostingEnv;
        }

        /*[HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] AddUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if(await _manager.CheckUser(model.UserName) != null)
            {
                return BadRequest("UserName Already SS Exist");
            }

            try
            {
                await _manager.AddAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }*/

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] AddUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if (await _manager.CheckUser(model.UserName) != null)
            {
                return BadRequest("UserName Already SS Exist");
            }

            try
            {

                //this is a simple white background image
                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                //Generate unique filename
                string uploadsFolder = Path.Combine(_hostingEnv.WebRootPath, "images");

                string filepath = uploadsFolder + "/" + myfilename + ".jpeg";

                string filename = "images/" + myfilename + ".jpeg";


                var bytess = Convert.FromBase64String(model.image);
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }
                model.imageUrl = filename;




                await _manager.AddAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User Created");

        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] EditUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                var myfilename = string.Format(@"{0}", Guid.NewGuid());

                //Generate unique filename
                string uploadsFolder = Path.Combine(_hostingEnv.WebRootPath, "images");

                string filepath = uploadsFolder + "/" + myfilename + ".jpeg";

                string filename = "images/" + myfilename + ".jpeg";


                var bytess = Convert.FromBase64String(model.image);
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }
                model.imageUrl = filename;


                await _manager.EditAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        /*[HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] UserLoginDto model)
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

            return Ok("User Updated");
        }
*/
        [HttpGet]
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

        [HttpPost]
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

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _manager.GetAllAsync());
        }
      
    }
}