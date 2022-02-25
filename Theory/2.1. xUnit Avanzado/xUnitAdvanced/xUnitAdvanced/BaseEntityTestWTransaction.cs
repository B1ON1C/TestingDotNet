using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitAdvanced.Utils;

namespace xUnitAdvanced
{
    public abstract class BaseEntityTestWTransaction : IClassFixture<DatabaseFixtureWTransaction>
    {
        protected DatabaseFixtureWTransaction dbFixture;

        protected BaseEntityTestWTransaction(DatabaseFixtureWTransaction databaseFixture)
        {
            this.dbFixture = databaseFixture;
        }

        protected abstract string tableName { get; }
        protected string getAllQuery => @"SELECT  *
                                        FROM  " + tableName;

        [Fact]
        public void Entities_GetAll_CanExecute()
        {
            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery, tran: dbFixture.SqlTransaction);
        }

        [Fact]
        public void Entities_GetAll_NonEmpty()
        {
            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery, tran: dbFixture.SqlTransaction);

            Assert.NotNull(obj);
        }

    }
}
