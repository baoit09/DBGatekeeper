using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DBGatekeeper.DataAccessServices.Repositories
{
    public class StudyRepository : Repository, IStudyRepository
    {
        #region Fields
        #endregion

        #region Ctors
        public StudyRepository(Database database) : 
            base(database)
        {
        }
        #endregion

        #region Methods
        public Hashtable GetStudy(string sqlString)
        {
            return base.GetEntity(sqlString);
        }
        #endregion
    }
}