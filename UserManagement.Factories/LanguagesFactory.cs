using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.Languages;
using UserManagement.Utilities;

namespace UserManagement.Factories
{
  public  class FieldFactory
    {
        public static Languages Create(LanguagesAddModel model, string userId)
        {
            var data = new Languages
            {
                lang_name = model.lang_name,
                lang_orientation = model.lang_orientation,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
               // lang_id = model.lang_id,
                

            };
            return data;
        }

        /* public static Languages Update(LanguagesUpdateModel model,User entity, string userId)
         {
             var data = new Languages
             {
                // entity.LangId = model.lang_id,
                 Status = Constants.RecordStatus.Active,
                 CreatedBy = userId ?? "0",
                 CreatedOn = Utility.GetDateTime(),
                 // lang_id = model.lang_id,


             };
             return data;
         }*/

        public static void Update(LanguagesUpdateModel model, User entity, string userId)
        {
            entity.LangId = model.lang_id;
        }
        public static void Create(LanguagesEditModel model, Languages entity, string userId)
        {
            entity.lang_name = model.lang_name;
            entity.lang_orientation = model.lang_orientation;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();

        }
    }
}
