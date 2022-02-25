using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitAdvanced
{
    public interface IEntity<T>
    {
        T GetEntity(IDataReader reader);
    }
}
