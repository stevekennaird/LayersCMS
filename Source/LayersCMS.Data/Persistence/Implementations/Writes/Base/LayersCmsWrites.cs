using LayersCMS.Data.Domain;
using ServiceStack.OrmLite;
using System.Data;

namespace LayersCMS.Data.Persistence.Implementations.Writes.Base
{
    public abstract class LayersCmsWrites<T> : LayersCmsDb where T : LayersCmsDomainObject, new()
    {
        public T Insert(T obj)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                conn.Insert(obj);
                return obj;
            }
        }

        public T Update(T obj)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                conn.Update(obj, x => x.Id == obj.Id);
                return obj;
            }
        }

        public void Delete(T obj)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                conn.Delete<T>(x => x.Id == obj.Id);
            }
        }
    }
}
