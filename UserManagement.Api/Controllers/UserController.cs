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
using UserManagement.Models.Languages;
using UserManagement.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using Microsoft.AspNetCore.Identity;
using UserManagement.DataLayer;

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
        private readonly UserManager<AppUser> _userManager;


        public UserController(IHostingEnvironment hostingEnv, IConfiguration configuration, IUserManager manager,
            IHostingEnvironment environment, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _manager = manager;
            _environment = environment;
            _hostingEnv = hostingEnv;
            _userManager = userManager;
        }

        
        [HttpPost]
      [Authorize]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] AddUserModel model)
        {
            var header = Request.Headers["CompanyId"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if (await _manager.CheckUser(model.UserName) != null)
            {
                return BadRequest("UserName Already SS Exist");
            }

            if (await _manager.CheckEmail(model.Email) != null)
            {
                return BadRequest("Email Already SS Exist");
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




                await _manager.AddAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User Created");

        }

        [HttpPost]
       [Authorize]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] EditUserModel model)
        {
            var header = Request.Headers["CompanyId"];

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


                await _manager.EditAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User Updated");
        }

       
        [HttpGet]
        [Authorize]
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

        [HttpPost]
        [Authorize]
        [Route("paged-result")]
        public async Task<IActionResult> PagedResult(JqDataTableRequest model)
        {
            var header = Request.Headers["CompanyId"];

            return Ok(await _manager.GetPagedResultAsync(model, Convert.ToInt32(header)));
        }

        [HttpPost]
        [Authorize]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var header = Request.Headers["CompanyId"];

            await _manager.DeleteAsync(id, Convert.ToInt32(header));

            return Ok("Deleted");
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
        [Route("editImg")]
        public async Task<IActionResult> EditImg([FromBody] EditImgModel model)
        {
            var header = Request.Headers["CompanyId"];

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


                await _manager.EditImgAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Image Updated");
        }

        [HttpPost]
        [Authorize]
        [Route("toggle-status/{id}")]
        public async Task<IActionResult> ToggleStatus(int id, int status)
        {
            var header = Request.Headers["CompanyId"];


            var user = new UserStatus();
            user.userid = id;
            if (status == 1)
            {
                user.status = Constants.RecordStatus.Active;
            }
            else
            if (status == 2)
            {
                user.status = Constants.RecordStatus.Inactive;
            }
            else
            {
                user.status = Constants.RecordStatus.Deleted;

            }

            await _manager.UpdateStatus(user, header.ToString());
            return Ok("Status Updated");
        }

    }
}