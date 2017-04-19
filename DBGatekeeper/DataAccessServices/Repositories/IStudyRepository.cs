using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGatekeeper.DataAccessServices.Repositories
{
    public interface IStudyRepository : IRepository
    {
        Hashtable GetStudy(string sqlString);
    }
}
