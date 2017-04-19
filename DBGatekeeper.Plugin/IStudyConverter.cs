using System.Collections;

namespace DBGatekeeper.Plugin
{
    public interface IStudyConverter
    {
        Hashtable Convert(Hashtable srcStudy);
    }
}
