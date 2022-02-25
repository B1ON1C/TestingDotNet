using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitAdvanced.Utils;

namespace xUnitAdvanced
{
    [Collection("DB")]
    public class EmployeesWBaseEntityAndCollectionTest : BaseEntityWCollectionTest
    {
        private readonly List<EmployeeEntity> listEmployees;
        public EmployeesWBaseEntityAndCollectionTest(DatabaseFixture databaseFixture) : 
                base(databaseFixture) { 
            listEmployees = DBUtils.ExecuteReaderToList<EmployeeEntity>(
                dbFixture.Db, getAllQuery
            );
        }

        protected override string tableName => "HumanResources.Employee";


        private readonly char[] ValidGenders = { 'M', 'F' };

        [Fact]
        public void Employees_CheckGenders_OnlyMFValues()
        {
            Assert.All(listEmployees, e => 
                Assert.Contains(e.Gender, ValidGenders)
            );
        }

        private readonly DateTime MIN_BIRTH_DATE = new DateTime(1930, 1, 1);

        [Fact]
        public void Employees_CheckBirthDates_YoungerThan1930()
        {
            Assert.All(listEmployees, e => 
                Assert.True(e.BirthDate >= MIN_BIRTH_DATE)
            );
        }
    }
}
