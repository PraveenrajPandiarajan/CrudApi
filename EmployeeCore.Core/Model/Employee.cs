using EmployeeEntity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web.Mvc;

namespace EmployeeCore.Core.Model
{
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_Of_Joining { get; set; }
        public string? Date { get; set; }
        public int Age { get; set; }
        public int? Expereince { get; set; }
        public long? Contact_Number { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Confirm_Password { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Create_Time_Stamp { get; set; }
        public DateTime Update_Time_Stamp { get; set; }
    
        public int? Location_Id { get; set; }
       
        public string? Location { get; set; }


    }
}
