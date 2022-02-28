using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.EmailSetting;
using UserManagement.Utilities;

namespace UserManagement.Factories
{
    public class EmailSettingFactory
    {
        public static EmailSetting Create(EmailSettingAddModel model, string userId,string header)
        {
            var data = new EmailSetting
            {
                Email = model.Email,
                password = model.password,
                Portnumber = model.Portnumber,
                DeletedBy = model.DeletedBy,
              
                CreatedOn = Utility.GetDateTime(),
                CreatedBy = userId ?? "0",
                Description = model.description,
                SmtpNo = model.smtpNo,
                CompanyId = Convert.ToInt32(header),
          

            };
            return data;
        }

        public static void Create(EmailSettingEditModel model, EmailSetting entity, string userId,string header)
        {

            entity.Email = model.Email;
            entity.password = model.password;
            entity.Portnumber = model.Portnumber;
            entity.DeletedBy = model.DeletedBy;
            entity.Description = model.description;
            entity.SmtpNo = model.smtpNo;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.CompanyId = Convert.ToInt32(header);


        }
    }
}
