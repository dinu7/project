using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace EmployeeMaster.Models
{
    public class db
    {
        SqlConnection con;
        public db()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("Date").GetSection("ConnectionString").Value);
        }
        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }

   
}
