using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaster.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string EmailID { get; set; }
        public string MobileNO { get; set; }
        public DateTime DOB { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBY { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
