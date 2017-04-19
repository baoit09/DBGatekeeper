using System.Collections;

namespace DBGatekeeper.Plugin
{
    public interface IPatientConverter
    {
        Hashtable Convert(Hashtable srcPatient);
    }
}
