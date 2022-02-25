using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitAdvanced
{
    public class EmployeeEntity : IEntity<EmployeeEntity>
    {
        public string LoginID { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public char MaritalStatus { get; set; }

        public EmployeeEntity GetEntity(IDataReader reader)
        {
            return new EmployeeEntity()
            {
                LoginID = (string)reader[nameof(LoginID)],
                BirthDate = DateTime.Parse(reader[nameof(BirthDate)].ToString()),
                Gender = (reader[nameof(Gender)].ToString()).FirstOrDefault(),
                MaritalStatus = (reader[nameof(MaritalStatus)].ToString()).FirstOrDefault()
            };
        }
    }
}
