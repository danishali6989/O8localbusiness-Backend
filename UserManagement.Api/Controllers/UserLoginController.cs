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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using System.Threading.Tasks;
using System.Security.Claims;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.WebUtilities;
using UserManagement.Infrastructure.Services;
using System.Security.Cryptography;
using System.Net.Mail;
using System.IO;
using UserManagement.Models.EmailSetting;
using UserManagement.Entities;
using UserManagement.DataLayer;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class UserLoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager _manager;
        private readonly IEmailSettingManager _manager1;

        private readonly IEmailSettingRepository _repository;

        private readonly IHostingEnvironment _environment;
        private readonly IEmailService _mailservice;

        public UserLoginController(IEmailSettingRepository repository, IEmailSettingManager manager1, IConfiguration configuration, IUserManager manager,
          IHostingEnvironment environment, IEmailService mailservice)
        {
            _repository = repository;
            _configuration = configuration;
           _manager = manager;
            _manager1 = manager1;
            _environment = environment;
            _mailservice = mailservice;
            
        }


        [HttpPost]
        [Route("UserLoginTwoStep2")]
        public async Task<IActionResult> LoginTwoStep(UserLoginTwo model)
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
                    var user = _manager.UserAllReadyLogin(data.Id);
                    if (model.UserName == "riyaztrad" || model.UserName == "Admin" || model.UserName == "Manager" || model.UserName == "Employee")
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
                            
                            if (data.otp == model.otp)

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
                            else
                            {
                                return BadRequest("Invalid Otp");
                            }
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
        [Route("UserLoginTwoStep1")]
        public async Task<IActionResult> LoginTwoStep(UserLoginModel model,int id)
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
                   
                    var user = _manager.UserAllReadyLogin(data.Id);
                    if (model.UserName == "riyaztrad" || model.UserName == "Admin" || model.UserName == "Manager" || model.UserName == "Employee")
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

                            Random generator = new Random();
                            String r = generator.Next(0, 1000000).ToString("D6");
                            await _manager.saveOtp(data.Email, Convert.ToInt32(r));

                            var data1 = new
                            {

                                otp = Convert.ToInt32(r),

                                msg = "OTP send",


                            };
                           
                            
                            

                            EmailSetting email1 = new EmailSetting();
                            email1 = await _repository.GetAsync1(id);
                            


                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient();
                            mail.From = new MailAddress(email1.Email);
                           
                          
                            mail.To.Add(email1.Email);
                             mail.Subject = "Login OTP";
                          
                            mail.Body = "<Html>"
                                         + "<head>" +

                                         "</head>" +
                                         "<body>" +
                                         "<div style='background: #f2f3f8; padding: 50px 0'>" +
                                         "<div style = 'max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);width: 450px; margin:0 auto;background: #fff; padding: 20px;'>" +
                                         "<h1 style='color:#1e1e2d; font-weight:500;font-size:32px;font-family:'Rubik',sans-serif;text-align:center;'>You have requested to Login to your account</h1>" +
                                         "<p style='text - align:center; font - family:'Rubik',sans - serif; '>Follow the instructions to loggin into your account</p>" +
                                         " <p style='text - align:center; font - family:'Rubik',sans - serif; '>Please use the otp to loggin into your account,this otp is valid upto 5 minutes : <strong><span>" +
                                         +data1.otp +
                                         "</span></strong></p>" +
                                         "</div>" +
                                         "</div>" +
                                         "</body>" +
                                    "</Html>";
                            mail.IsBodyHtml = true;
                            SmtpServer.Host = "smtp.gmail.com";
                           
                            SmtpServer.Port = email1.Portnumber;
                          
                            SmtpServer.UseDefaultCredentials = false;
                            
                            SmtpServer.Credentials = new System.Net.NetworkCredential(email1.Email,email1.password);
                            SmtpServer.EnableSsl = true;
                            SmtpServer.Send(mail);


                            return Ok(data1);
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
        [Route("Userlogin")]
        public async Task<IActionResult> Login(UserLoginModelOne model)
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
                    if (model.UserName == "riyaztrad"||model.UserName== "Admin"|| model.UserName == "Manager" || model.UserName == "Employee")
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
                                      new Claim("CompanyId", data.CompanyId.ToString()),
                                      new Claim("Language",data.LangId.ToString()),
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
        [Route("forgotPassword")]
        public async Task<IActionResult> FogotPassword(string email,int id)
        {
            try
            {
                var exist = await _manager.isExist(email);
                if (exist != null)
                {
                    Random generator = new Random();
                    String r = generator.Next(0, 1000000).ToString("D6");
                    await _manager.saveOtp(email, Convert.ToInt32(r));

                    var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
                    var randomBytes = new byte[40];
                    rngCryptoServiceProvider.GetBytes(randomBytes);
                    // convert random bytes to hex string
                    var token = BitConverter.ToString(randomBytes).Replace("-", "");

                    // var token = await _manager.GeneratePasswordResetTokenAsync(exist);
                    var encodedToken = Encoding.UTF8.GetBytes(token);
                    var validToken = WebEncoders.Base64UrlEncode(encodedToken);

                    // string url = $"{_configuration["AppUrl"]}/ResetPassword/email={email}&token={validToken}";

                    // await _mailservice.SendAsync(email, "Reset Password", "<h1>follow the instruction to reset your password </h1>" + $"<p>To reset your password <a href= '{url}'></a></p>");

                    var data = new
                    {
                        otp = Convert.ToInt32(r),
                        msg = "OTP send",


                    };

                    EmailSetting email1 = new EmailSetting();
                    email1 = await _repository.GetAsync1(id);

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient();
                 
                    mail.From = new MailAddress(email1.Email, "User Management");
                    mail.To.Add(email1.Email);
                    mail.Subject = "Reset Password";
                    mail.Body = "<Html>"
                                 + "<head>" +

                                 "</head>" +
                                 "<body>" +
                                 "<div style='background: #f2f3f8; padding: 50px 0'>" +
                                 "<div style = 'max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);width: 450px; margin:0 auto;background: #fff; padding: 20px;'>" +
                                 "<h1 style='color:#1e1e2d; font-weight:500;font-size:32px;font-family:'Rubik',sans-serif;text-align:center;'>You have requested to reset your password</h1>" +
                                 "<p style='text - align:center; font - family:'Rubik',sans - serif; '>Follow the instructions to reset your password</p>" +
                                 " <p style='text - align:center; font - family:'Rubik',sans - serif; '>Please use the otp to reset your password : <strong><span>" +
                                 +data.otp +
                                 "</span></strong></p>" +
                                 "</div>" +
                                 "</div>" +
                                 "</body>" +
                            "</Html>";
                    mail.IsBodyHtml = true;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.Port = email1.Portnumber;
                   
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(email1.Email, email1.password);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    
                    return Ok(data);




                   

                }
                else
                {
                    return BadRequest("User not found");
                }
            }catch(Exception ex)
            {
                throw ex;
            }

        }


        /*public  void SendEmail()
        {
            try
            {             

                    string FromMail = "zubair.softw@gmail.com";
                    string emailTo = "zubair.softw@gmail.com";
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("mail.gmail.com");
                    mail.From = new MailAddress(FromMail,"reest");
                    mail.To.Add(emailTo);
                    mail.Subject = "hel";
                    mail.Body = "body";
                    mail.IsBodyHtml = true;
                    SmtpServer.Port = 587;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("zubair.softw@gmail.com", "zubair@sft123#");
                    SmtpServer.EnableSsl = false;
                    SmtpServer.Send(mail);
                    
               

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
*/
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
     //    [Authorize]
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
