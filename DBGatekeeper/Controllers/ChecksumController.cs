using DBGatekeeper.BusinessLogicServices;
using DBGatekeeper.Helpers;
using System.Collections;
using System.Web.Http;

namespace DBGatekeeper.Controllers
{
    public class ChecksumController : ApiController
    {
        #region Fields

        private readonly IEntityService _entityService;
        private readonly IChecksumService _checksumService;
        private readonly EntityConverterHelper _entityConverterHelper;

        #endregion

        #region Ctors

        public ChecksumController(IChecksumService checksumService, IEntityService entityService, EntityConverterHelper entityConverterHelper)
        {
            _checksumService = checksumService;
            _entityService = entityService;
            _entityConverterHelper = entityConverterHelper;
        }

        #endregion

        #region HTTP Methods

        // POST api/checksum
        public Hashtable Post([FromBody]dynamic value)
        {
            Hashtable result = new Hashtable();

            string sqlString = value.SQLString.Value;
            string sEntityType = value.EntityType;
            string sEthereumAddress = value.EthereumAddress.Value;

            Hashtable srcEntity = _entityService.GetEntity(sqlString);
            Hashtable destEntity = _entityConverterHelper.Convert(srcEntity, sEntityType);

            string sChecksum = _checksumService.GenerateChecksum(destEntity);

            result.Add("Checksum", sChecksum);

            return result;
        }

        #endregion
    }
}
