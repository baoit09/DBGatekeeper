using System.Collections;

namespace DBGatekeeper.BusinessLogicServices
{
    public interface IStudyService
    {
        Hashtable GetStudy(string sqlString);
    }
}
