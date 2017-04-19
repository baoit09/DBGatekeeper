using DBGatekeeper.BusinessLogicServices;
using DBGatekeeper.Helpers;
using System.Collections;
using System.Web.Http;

namespace DBGatekeeper.Controllers
{
    public class PatientController : ApiController
    {
        #region Fields

        private readonly IPatientService _patientService;
        private readonly IChecksumService _checksumService;
        private readonly EntityConverterHelper _entityConverterHelper;

        #endregion

        #region Ctors

        public PatientController(IPatientService patientService, IChecksumService checksumService, EntityConverterHelper entityConverterHelper)
        {
            _patientService = patientService;
            _checksumService = checksumService;
            _entityConverterHelper = entityConverterHelper;
        }

        #endregion

        #region HTTP Methods

        // POST api/patient
        public Hashtable Post([FromBody]dynamic value)
        {
            if (value == null)
                return null;

            string sqlString = value.SQLString.Value;
            string checkSum = value.Checksum.Value;

            Hashtable srcPatient = _patientService.GetPatient(sqlString);
            Hashtable destPatient = _entityConverterHelper.Convert(srcPatient, "Patient");

            string computedChecksum = _checksumService.GenerateChecksum(destPatient);

            if (!string.Equals(checkSum, computedChecksum))
                return null;

            return destPatient;
        }

        #endregion
    }
}
