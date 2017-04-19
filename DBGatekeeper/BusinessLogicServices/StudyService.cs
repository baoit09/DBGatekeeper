using DBGatekeeper.DataAccessServices.Repositories;
using System.Collections;

namespace DBGatekeeper.BusinessLogicServices
{
    public class StudyService : IStudyService
    {
        #region Fields
        private readonly IStudyRepository _studyRepository;
        #endregion

        #region Ctors
        public StudyService(IStudyRepository studyRepository)
        {
            _studyRepository = studyRepository;
        }
        
        #endregion

        #region Methods
        public Hashtable GetStudy(string sqlString)
        {
            return _studyRepository.GetStudy(sqlString);
        }
        #endregion
    }
}