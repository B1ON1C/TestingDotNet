using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace xUnitAdvanced
{
    public class DatabaseFixture_old : IDisposable
    {
        private const string cn = "Server=localhost;Database=AdventureWorks2019;" +
                                "Integrated Security=SSPI;TrustServerCertificate=True";
        public SqlConnection Db { get; private set; }

        public DatabaseFixture_old()
        {
            Db = new SqlConnection(cn);

            // ... initialize data in the test database ...
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
    }
}
