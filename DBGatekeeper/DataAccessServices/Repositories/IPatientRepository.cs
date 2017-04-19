using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBGatekeeper.DataAccessServices.Repositories
{
    public interface IPatientRepository
    {
        Hashtable GetPatient(string sqlString);
    }
}