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
    public class DepartmentsWBaseEntityTest : BaseEntityTestWTransaction, IClassFixture<DatabaseFixtureWTransaction>
    {
        public DepartmentsWBaseEntityTest(DatabaseFixtureWTransaction databaseFixture) : base(databaseFixture) { }

        protected override string tableName => "HumanResources.Department";

        protected int insertDepartment(string name, string groupName, DateTime modifiedDate, SqlTransaction tran = null) {
            string sqlQuery = $@"INSERT INTO {tableName} (Name, GroupName, ModifiedDate)
                                VALUES (@Name, @GroupName, @ModifiedDate); 
                                SELECT @@IDENTITY";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Name", name));
            param.Add(new SqlParameter("@GroupName", groupName));
            param.Add(new SqlParameter("@ModifiedDate", modifiedDate));

            return Convert.ToInt32(DBUtils.ExecuteScalar(dbFixture.Db, sqlQuery, param.ToArray(), tran));
        }

        protected int deleteDepartment(int ID)
        {
            string sqlQuery = $@"DELETE FROM {tableName} WHERE DepartmentID = @ID";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ID", ID));

            return DBUtils.ExecuteNonQuery(dbFixture.Db, sqlQuery, param.ToArray(), dbFixture.SqlTransaction);
        }

        [Fact]
        public void InsertDepartment_NewEntity_ShouldSucceed()
        {
            int idResult = insertDepartment("TEST", "TEST GROUP", DateTime.Now, dbFixture.SqlTransaction);
            bool inserted = idResult > 0;
            Assert.True(inserted);

            //Clean-up
            Assert.Equal(1, deleteDepartment(idResult));
        }

        [Fact]
        public void InsertDepartment_NewEntityWTransaction_ShouldSucceed()
        {
            //The transaction managemente is moved to the fixture
            //SqlTransaction tran = dbFixture.Db.BeginTransaction();
            int idResult = insertDepartment("TEST2", "TEST GROUP", DateTime.Now, dbFixture.SqlTransaction);
            bool inserted = idResult > 0;
            Assert.True(inserted);

            //The transaction managemente is moved to the fixture
            //tran.Rollback();
        }
    }
}
