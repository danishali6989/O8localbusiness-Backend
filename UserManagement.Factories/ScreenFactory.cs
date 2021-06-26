using UserManagement.Entities;
using UserManagement.Models.UserLogin;
using UserManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Models.Screen;

namespace UserManagement.Factories
{
    public class ScreenFactory
    {
        public static ScreenDetail Create(ScreenAddModel model, string userId)
        {
            var data = new ScreenDetail
            {
                ScreenName=model.ScreenName,
                ScreenCode=model.ScreenCode,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }
        public static void Create(ScreenEditModel model, ScreenDetail entity, string userId)
        {
            entity.ScreenCode = model.ScreenCode;
            entity.ScreenName = model.ScreenName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
