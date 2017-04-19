using DBGatekeeper.DataAccessServices.Repositories;
using DBGatekeeper.Helpers;
using System.Collections;
using System.Configuration;

namespace DBGatekeeper.BusinessLogicServices
{
    public class ChecksumService : IChecksumService
    {
        #region Fields
        private readonly IRepository _repository;
        #endregion

        public ChecksumService(IRepository repository)
        {
            _repository = repository;
        }
        public string GenerateChecksum(string sqlString)
        {
            Hashtable hastTableData = _repository.GetEntity(sqlString);
            return GenerateChecksum(hastTableData);
        }

        public string GenerateChecksum(object obj)
        {
            string Key = ConfigurationManager.AppSettings["MACTripleDESKey"];
            string hash = obj.GetMACTripleDESHash(Key);
            return hash;
        }
    }
}