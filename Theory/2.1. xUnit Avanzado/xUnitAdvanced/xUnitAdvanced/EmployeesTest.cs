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
    public class EmployeesTest : IClassFixture<DatabaseFixture_old>
    {
        private DatabaseFixture_old dbFixture;

        public EmployeesTest(DatabaseFixture_old databaseFixture)
        {
            this.dbFixture = databaseFixture;
        }

        private const string tableName = "HumanResources.Employee";
        private const string getAllQuery = @"SELECT  *
                                            FROM  " + tableName;

        [Fact]
        public void Employees_GetAll_CanExecute()
        {
            dbFixture.Db.Open();
            
            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery);

            dbFixture.Db.Close();
        }

        [Fact]
        public void Employees_GetAll_NonEmpty()
        {
            dbFixture.Db.Open();

            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery);

            Assert.NotNull(obj);
            dbFixture.Db.Close();
        }

    }
}
