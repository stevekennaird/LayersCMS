using System.Data;
using LayersCMS.Data.Domain;
using ServiceStack.OrmLite;

namespace LayersCMS.Data.Persistence.Implementations.Reads.Base
{
    public class LayersCmsReads<T> : LayersCmsDb where T : LayersCmsDomainObject, new()
    {
        public T GetById(int id)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                return conn.QuerySingle<T>(new { Id = id });
            }
        }
    }
}
