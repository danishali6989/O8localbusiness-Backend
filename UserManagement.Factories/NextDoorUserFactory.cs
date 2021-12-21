using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.NextDoorUser;
using UserManagement.Utilities;

namespace UserManagement.Factories
{
    public class NextDoorUserFactory
    {

        public static NextDoorUser Create(AddNextDoorUserModel model, string userId)
        {
            var data = new NextDoorUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Email = model.Email,
                Password = Utility.Encrypt(model.Password),
                StreetAdress = model.StreetAdress,
                ApartmentNo = model.ApartmentNo,
                Lan = model.Lan,
                Lat = model.Lat,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
               

            };
            return data;
        }
    }
}
