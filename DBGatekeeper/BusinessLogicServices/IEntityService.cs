using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBGatekeeper.BusinessLogicServices
{
    public interface IEntityService
    {
        Hashtable GetEntity(string sqlString);
    }
}