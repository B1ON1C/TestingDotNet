using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitAdvanced.Utils;

namespace xUnitAdvanced
{
    public class EmployeesConstructorTest
    {
        private const string cn = "Server=localhost;Database=AdventureWorks2019;" +
                                "Integrated Security=SSPI;TrustServerCertificate=True";
        public SqlConnection Db { get; private set; }

        public EmployeesConstructorTest()
        {
            Db = new SqlConnection(cn);

            // ... initialize data in the test database ...
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }

        [Fact]
        public void Employees_GetAll_CanExecute()
        {
            Db.Open();
            SqlCommand command = Db.CreateCommand();
            command.CommandText = @"SELECT  *
                                FROM  HumanResources.Employee";
            var obj = command.ExecuteScalar();
            Db.Close();
        }

        [Fact]
        public void Employees_GetAll_NonEmpty()
        {
            Db.Open();
            SqlCommand command = Db.CreateCommand();
            command.CommandText = @"SELECT  *
                                FROM  HumanResources.Employee";
            var obj = command.ExecuteScalar();
            Assert.NotNull(obj);
            Db.Close();
        }
    }
}
