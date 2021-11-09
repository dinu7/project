using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace EmployeeMaster.Models
{
    public class Employee
    {
        string Connection;
        public Employee(string str)
        {
            Connection = str;
            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4U5NJOS;Initial Catalog=employeeBD; Integrated Security=true");

        }

        public int AddEmp(EmployeeModel emp)
        {
            emp.type = "Insert";
            var msg = 0;
            using (var connection = new SqlConnection(Connection))
            {
            
               msg=connection.Execute("sp_EmployeeMaster", emp, commandType: CommandType.StoredProcedure);
            }



            //string sql = "insert into EmployeeMaster values'" + emp.FirstName + "','" + emp.LastName + "','" + emp.Sex + "','" + emp.EmailID + "','" + emp.MobileNO + "','" + emp.DOB + "','" + emp.IsActive + "','" + emp.CreatedBY + "','" + emp.CreatedDate + "','" + emp.ModifiedBy + "','" + emp.ModifiedDate + "'";
            //var msg = 0;

            //using (var connection = new SqlConnection(Connection))
            //{
            //    msg = connection.Execute(sql);
            //}
            return msg;
        }

        public IEnumerable<EmployeeModel> AllEmployee()
        {
            
           // List<EmployeeModel> employee;
            using (var connection = new SqlConnection(Connection))
            {
                var param = new DynamicParameters(new {ID = 0});
               var employee = connection.Query<EmployeeModel>("Fetch_SP_EmployeeMaster", param, commandType: CommandType.StoredProcedure);
                return employee;

            }
            //IEnumerable<EmployeeModel> employee = null;
            //
            //{
            //    employee = connection.Query<EmployeeModel>("select EmployeeID,FirstName,LastName,Sex,EmailID,MobileNO,DOB,IsActive,CreatedBY,CreatedDate,ModifiedBy,ModifiedDate from EmployeeMaster");

            //}
           
        }

        public int Delete(int id)
        {
            EmployeeModel emp = new EmployeeModel();
            //var msg = 0;
            //using (var connection = new SqlConnection(Connection))
            //{
            //    //   connection.Execute("DELETE FROM employeeDeatails WHERE employeeId=@Id", new { Id = id });
            //    msg = connection.Execute("DELETE FROM employeeDeatails  WHERE employeeId=" + id + "");


            //}

           
            var msg = 0;
            using (var connection = new SqlConnection(Connection))
            {

                //var values = new { type = "Delete", EmployeeID =id };
                var param = new { EmployeeID = id, type = "Delete", firstName = "", lastName = "", sex = "", emailID = "", mobileNO = "", dob = "", isActive = false, createdBY = 1, createdDate = "", modifiedBy = "", modifiedDate = "" };
                msg = connection.Execute("sp_EmployeeMaster", param, commandType: CommandType.StoredProcedure);
            }

            return msg;
        }

        public EmployeeModel GetEmpById(int id)
        {


           // EmployeeModel emp = new EmployeeModel();
            using (var connection = new SqlConnection(Connection))
            {
                var param = new DynamicParameters(new { ID = id });
               var emp = connection.Query<EmployeeModel>("Fetch_SP_EmployeeMaster", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return emp;
            }
            //EmployeeModel employee = null;
            //using (var connection = new SqlConnection(Connection))
            //{
            //    // employee = connection.Query<EmployeeModel>("SELECT * FROM employeeDeatails WHERE employeeId=@Id", new { Id = id }).First();
            //    // employee = connection.Query<EmployeeModel>("select * from employeeDeatails").Where(e=>e.employeeId.Equals(id)).First();
            //    employee = connection.Query<EmployeeModel>("SELECT * FROM employeeDeatails WHERE employeeId=" + id + "").First();

            //}
           // return st;
        }

        public int Update(EmployeeModel emp)
        {
            emp.type = "Update";
            var msg = 0;
            using (var connection = new SqlConnection(Connection))
            {
                msg = connection.Execute("sp_EmployeeMaster", emp, commandType: CommandType.StoredProcedure);
            }
            //string sql = "update employeeDeatails set employeeCode='" + emp.employeeCode + "',employeeName='" + emp.employeeName + "', address='" + emp.address + "', userName='" + emp.userName + "', password='" + emp.password + "' where employeeId=" + emp.employeeId;
            //var msg = 0;
            //using (var connection = new SqlConnection(Connection))
            //{
            //    msg = connection.Execute(sql);

            //}
            return msg;
        }
    }
}


