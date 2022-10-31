using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCore.Core.Model
{
    public class EmployeeLocation
    {
        public int Location_Id { get; set; }
        public string Location { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Create_Time_Stamp { get; set; }
        public DateTime Update_Time_Stamp { get; set; }
    }
}
