using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGatekeeper.DataAccessServices.Repositories
{
    public interface IRepository
    {
        Database Database { get; set; }
        Hashtable GetEntity(string sqlString);
    }
}
