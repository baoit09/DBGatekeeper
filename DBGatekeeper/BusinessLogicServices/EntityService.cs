using DBGatekeeper.DataAccessServices.Repositories;
using System.Collections;

namespace DBGatekeeper.BusinessLogicServices
{
    public class EntityService : IEntityService
    {
        #region Fields

        private readonly IRepository _repository;

        #endregion

        #region Ctors

        public EntityService(IRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public Hashtable GetEntity(string sqlString)
        {
            return _repository.GetEntity(sqlString);
        }

        #endregion
    }
}