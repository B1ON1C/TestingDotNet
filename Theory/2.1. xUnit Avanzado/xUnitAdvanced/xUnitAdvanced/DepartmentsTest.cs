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
    public class DepartmentsTest : IClassFixture<DatabaseFixture_old>
    {
        private DatabaseFixture_old dbFixture;

        public DepartmentsTest(DatabaseFixture_old databaseFixture)
        {
            this.dbFixture = databaseFixture;
        }

        private const string tableName = "HumanResources.Department";
        private const string getAllQuery = @"SELECT  *
                                            FROM  " + tableName;

        [Fact]
        public void Departments_GetAll_CanExecute()
        {
            dbFixture.Db.Open();
            
            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery);

            dbFixture.Db.Close();
        }

        [Fact]
        public void Departments_GetAll_NonEmpty()
        {
            dbFixture.Db.Open();

            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery);

            Assert.NotNull(obj);
            dbFixture.Db.Close();
        }
    }
}
