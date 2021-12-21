﻿using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class NextDoorUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string StreetAdress { get; set; }
        public int ApartmentNo { get; set; }
        public string Email { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        //public DateTime? LastLogin { get; set; }
        public string UpdatedBy { get; set; }

      
        

    }
}
