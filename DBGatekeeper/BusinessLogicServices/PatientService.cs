using DBGatekeeper.DataAccessServices.Repositories;
using System.Collections;

namespace DBGatekeeper.BusinessLogicServices
{
    public class PatientService : IPatientService
    {
        #region Fields
        private readonly IPatientRepository _patientRepository;
        #endregion

        #region Ctors
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        
        #endregion

        #region Methods
        public Hashtable GetPatient(string sqlString)
        {
            return _patientRepository.GetPatient(sqlString);
        }
        #endregion
    }
}