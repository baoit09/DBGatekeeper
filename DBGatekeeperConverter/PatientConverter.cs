using DBGatekeeper.Plugin;
using System.Collections;

namespace DBGatekeeperConverter
{
    public class PatientConverter : IPatientConverter
    {
        public Hashtable Convert(Hashtable srcPatient)
        {
            Hashtable desPatient = (Hashtable)srcPatient.Clone();

            desPatient["PatientName"] = srcPatient["PatientName"] + "Edited";

            return desPatient;
        }
    }
}
