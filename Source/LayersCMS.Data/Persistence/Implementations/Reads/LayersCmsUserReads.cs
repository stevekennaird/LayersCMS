using LayersCMS.Data.Domain.Core.Security;
using LayersCMS.Data.Persistence.Implementations.Reads.Base;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Util.Security.Interfaces;
using ServiceStack.OrmLite;
using System.Data;

namespace LayersCMS.Data.Persistence.Implementations.Reads
{
    public class LayersCmsUserReads : LayersCmsReads<LayersCmsUser>, ILayersCmsUserReads
    {
        #region Constructor and Dependencies

        private readonly IHashHelper _hashHelper;

        public LayersCmsUserReads(IHashHelper hashHelper)
        {
            _hashHelper = hashHelper;
        }

        #endregion

        #region Implementation of ILayersCmsReads<LayersCmsUser>

        public LayersCmsUser GetForLogin(string emailAddress, string plainTextPassword)
        {
            // Hash the plain text password so we can query the database with it
            string hashedPassword = _hashHelper.HashString(plainTextPassword);

            using (IDbConnection conn = GetDbConnection())
            {
                return conn.FirstOrDefault<LayersCmsUser>(u => u.EmailAddress == emailAddress && u.Password == hashedPassword && u.Active == true);
            }
        }

        #endregion
    }
}
