using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitAdvanced.Utils;

namespace xUnitAdvanced
{
    public abstract class BaseEntityWCollectionTest 
    {
        protected DatabaseFixture dbFixture;

        protected BaseEntityWCollectionTest(DatabaseFixture databaseFixture)
        {
            this.dbFixture = databaseFixture;
        }

        protected abstract string tableName { get; }
        protected string getAllQuery => @"SELECT  *
                                        FROM  " + tableName;

        [Fact]
        [Trait("Category", "Base test")]
        public void Entities_GetAll_CanExecute()
        {
            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery);
        }

        [Fact]
        [Trait("Category", "Base test")]
        public void Entities_GetAll_NonEmpty()
        {
            var obj = DBUtils.ExecuteScalar(dbFixture.Db, getAllQuery);

            Assert.NotNull(obj);
        }

    }
}
