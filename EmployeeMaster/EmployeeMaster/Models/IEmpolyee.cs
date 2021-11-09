using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaster.Models
{
    interface IEmpolyee
    {
        public IEnumerable<EmployeeModel> AllEmployee();
        public EmployeeModel GetEmpById(int id);
        public int Delete(int id);
        public int Update(EmployeeModel e);
        public int AddEmp(EmployeeModel e);
    }
}
