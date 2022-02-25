using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Xunit;

namespace xUnitAdvanced
{
    public class DatabaseFixtureWTransaction : IDisposable
    {
        private const string cn = "Server=localhost;Database=AdventureWorks2019;" +
                                "Integrated Security=SSPI;TrustServerCertificate=True";
        public SqlConnection Db { get; private set; }
        public SqlTransaction SqlTransaction { get; private set; }

        public DatabaseFixtureWTransaction()
        {
            Db = new SqlConnection(cn);

            // ... initialize data in the test database ...
            Db.Open();
            SqlTransaction = Db.BeginTransaction();
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
            SqlTransaction.Rollback();
            Db.Close();
            Db.Dispose();
        }
    }
}
