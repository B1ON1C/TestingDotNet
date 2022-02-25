using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitAdvanced
{
    [Collection("DB")]
    public class DepartmentsWBaseEntityAndCollectionTest : BaseEntityWCollectionTest
    {
        public DepartmentsWBaseEntityAndCollectionTest(DatabaseFixture databaseFixture) : base(databaseFixture) { }

        protected override string tableName => "HumanResources.Department";
    }
}
