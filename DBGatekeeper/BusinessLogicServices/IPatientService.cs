using System.Collections;

namespace DBGatekeeper.BusinessLogicServices
{
    public interface IPatientService
    {
        Hashtable GetPatient(string sqlString);
    }
}