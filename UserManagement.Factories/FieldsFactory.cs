using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.Field;
using UserManagement.Utilities;

namespace UserManagement.Factories
{
    public class FieldsFactory
    {
        public static Field Create(FieldsAddModel model, string userId)
        {
            var data = new Field()
            {
                lang_id = model.lang_id,
                screen_id = model.screen_id,
                field = model.field,
                description = model.description,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                UpdatedBy = userId??"0",
                UpdatedOn = Utility.GetDateTime(),
               // Language = model.lang_id

            };
            return data;
        }

        public static void Create(FieldEditModel model, Field entity, string userId)
        {
            entity.lang_id = model.lang_id;
            entity.screen_id = model.screen_id;
            entity.field = model.field;
            entity.description =model.description;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();

        }
    }
}


