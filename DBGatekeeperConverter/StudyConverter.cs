using DBGatekeeper.Plugin;
using System.Collections;

namespace DBGatekeeperConverter
{
    public class StudyConverter : IStudyConverter
    {
        public Hashtable Convert(Hashtable srcStudy)
        {
            Hashtable desStudy = (Hashtable)srcStudy.Clone();

            desStudy["DiseaseName"] = srcStudy["DiseaseName"] + "Edited";

            return desStudy;
        }
    }
}
