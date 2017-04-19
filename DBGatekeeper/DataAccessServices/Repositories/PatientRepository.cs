using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections;

namespace DBGatekeeper.DataAccessServices.Repositories
{
    public class PatientRepository : Repository, IPatientRepository
    {
        #region Fields
        #endregion

        #region Ctors
        public PatientRepository(Database _database)
            : base(_database)
        {
        }
        #endregion

        #region Methods
        public Hashtable GetPatient(string sqlString)
        {
            return base.GetEntity(sqlString);
        }
        #endregion
    }
}