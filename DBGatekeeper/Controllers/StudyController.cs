using DBGatekeeper.BusinessLogicServices;
using DBGatekeeper.Helpers;
using System.Collections;
using System.Web.Http;

namespace DBGatekeeper.Controllers
{
    public class StudyController : ApiController
    {
        #region Fields

        private readonly IStudyService _StudyService;
        private readonly IChecksumService _checksumService;
        private readonly EntityConverterHelper _entityConverterHelper;

        #endregion

        #region Ctors

        public StudyController(IStudyService StudyService, IChecksumService checksumService, EntityConverterHelper entityConverterHelper)
        {
            _StudyService = StudyService;
            _checksumService = checksumService;
            _entityConverterHelper = entityConverterHelper;
        }

        #endregion

        #region HTTP Methods

        // POST api/Study
        public Hashtable Post([FromBody]dynamic value)
        {
            if (value == null)
                return null;

            string sqlString = value.SQLString.Value;
            string checkSum = value.Checksum.Value;

            Hashtable srcStudy = _StudyService.GetStudy(sqlString);
            Hashtable destStudy = _entityConverterHelper.Convert(srcStudy, "Study");

            string computedChecksum = _checksumService.GenerateChecksum(destStudy);

            if (!string.Equals(checkSum, computedChecksum))
                return null;

            return destStudy;
        }

        #endregion
    }
}
