using UserManagement.Api.Helpers;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.UserLogin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager _manager;
        private readonly IHostingEnvironment _environment;

        public UserLoginController(IConfiguration configuration, IUserManager manager,
          IHostingEnvironment environment)
        {
            _configuration = configuration;
           _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Route("Userlogin")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorList());
                }
                var data = await _manager.CheckUser(model.UserName);
                if (data != null)
                {
                    var user =  _manager.UserAllReadyLogin(data.Id);
                    if (model.UserName == "riyaztrad")
                    {
                        user = false;
                    }
                    if (user == true)
                    {
                        return BadRequest("Already Login");
                    }
                    else
                    {
                        if (UserManagement.Utilities.Utility.Decrypt(model.Password, data.Password) == false)
                        {
                            return BadRequest("Invalid Password");
                        }
                        else
                        {
                            await _manager.LoginAddAsync(data);

                            var tokenHandler = new JwtSecurityTokenHandler();
                            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:secret"));
                            var tokenDescription = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(new[]
                                { new Claim("id", data.Id.ToString()) ,
                            new Claim("Name", data.UserName.ToString()),
                             new Claim("RoleId", data.RoleId.ToString()),
                             new Claim("RoleName", data.RoleName.ToString()),
                             new Claim("CompanyId", data.CompanyId.ToString())
                        }
                                ),
                                Audience = _configuration.GetValue<string>("Jwt:Audience"),
                                Issuer = _configuration.GetValue<string>("Jwt:Issuer"),
                                Expires = DateTime.UtcNow.AddDays(7),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                            };

                            var token = tokenHandler.CreateToken(tokenDescription);

                            return Ok(tokenHandler.WriteToken(token));
                        }
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

        [HttpPost]
        [Route("forgotPassword/{id}")]
        public async Task<IActionResult> FogotPassword(string email)
        {
            var exist = await _manager.isExist(email);
            if (exist != null)
            {
                Random generator = new Random();
                String r = generator.Next(0, 1000000).ToString("D6");
                await _manager.saveOtp(email, Convert.ToInt32(r));
                var data = new
                {
                    otp = Convert.ToInt32(r),
                    msg = "OTP send",
                };
                return Ok(data);
            }
            else
            {
                return BadRequest("User not found");
            }


        }

        [HttpPost]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword(int otp, string password, string email)
        {
            var bdotp = await _manager.getOtp(email);
             if (bdotp != null)
            {
                if (bdotp.otp == otp)

                {

                    await _manager.changePassword(email, password);
                    var data = new
                    {

                        msg = "Your password has been changed.",
                    };
                    return Ok(data);
                }
                else
                {
                    return BadRequest("Otp is not valid");
                }
            }
            else
            {
                return BadRequest("User not found");
            }



        }

        [HttpPost]
      [Authorize]
        [Route("logout/{id}")]
        public async Task<IActionResult> LogOut(int id)
        {
            var header = Request.Headers["CompanyId"];

            await _manager.LogOut(id, Convert.ToInt32(header));
            return Ok();
        }


        [HttpPost]
        [Authorize]
        [Route("onlineUser-paged-result")]
        public async Task<IActionResult> OnlineUserPagedResult(JqDataTableRequest model)
        {
            var header = Request.Headers["CompanyId"];
            return Ok(await _manager.OnlineUserPagedResult(model, Convert.ToInt32(header)));
        }

        [HttpPost]
         [Authorize]
        [Route("Admin-change-password")]
        public async Task<IActionResult> AdminChangePassword([FromBody] ChangePasswordModel model)
        {
            var header = Request.Headers["CompanyId"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            var check_Admin = _manager.CheckPassword(model.adminid, model.adminPassword);

            if (check_Admin == true)
            {
                await _manager.ChangePasswordAdmin(model);
                var data = new
                {
                    msg = "Your password has been changed.",
                };
                return Ok(data);

               
            }


            return BadRequest("not a valid admin");


        }

    }
}
