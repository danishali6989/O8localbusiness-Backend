﻿using UserManagement.Dtos.UserLogin;
using UserManagement.Entities;
using UserManagement.Models.UserLogin;
using UserManagement.Models.User;

using UserManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Factories
{
    public class UserFactory
    {
        public static User Create(AddUserModel model, string userId, string header)
        {
            var data = new User
            {
                Usr_FName = model.FirstName,
                Usr_LName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                App_id = model.App_id,
                Finance_year = model.Finance_year,
                Ip_Address = model.Ip_Address,
                Password = Utility.Encrypt(model.Password),
                Mobile = model.Mobile,
                RoleId = model.RoleId,
                image = model.imageUrl,

                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                CompanyId = Convert.ToInt32(header),

            };
            return data;
        }
        public static void Create(EditUserModel model, User entity, string userId, string header)
        {
            entity.Usr_FName = model.FirstName;
            entity.Usr_LName = model.LastName;
            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.RoleId = model.RoleId;
            //  entity.Password = Utility.Encrypt(model.Password);
            entity.Mobile = model.Mobile;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.Ip_Address = model.Ip_Address;
            entity.Finance_year = model.Finance_year;
            entity.App_id = model.App_id;
            entity.CompanyId = Convert.ToInt32(header);
            entity.image = model.imageUrl;
        }
        public static void Create(UserStatus model, User entity, string userId, string header)
        {

            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.Status = model.status;
            entity.CompanyId = Convert.ToInt32(header);


        }
        public static void EditImag(EditImgModel model, User entity, string userId, string header)
        {

            //  entity.Password = Utility.Encrypt(model.Password);
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.image = model.imageUrl;
            entity.CompanyId = Convert.ToInt32(header);

        }


        public static LoginModule Login(UserDetailDto model)
        {
            var data = new LoginModule
            {
                UserId = model.Id,
                status = true,
                createdOn = Utility.GetDateTime(),
                RoleId = model.RoleId,
                CompanyId = model.CompanyId


            };
            return data;
        }
    }
}
