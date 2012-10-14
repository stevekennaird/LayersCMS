using LayersCMS.Data.Domain;

namespace LayersCMS.Data.Persistence.Interfaces.Writes.Base
{
    public interface ILayersCmsWrites<T> where T : LayersCmsDomainObject
    {
        T Insert(T obj);
    }
}