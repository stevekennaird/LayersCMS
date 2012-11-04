using LayersCMS.Data.Domain;

namespace LayersCMS.Data.Persistence.Interfaces.Writes.Base
{
    public interface ILayersCmsWrites<T> where T : LayersCmsDomainObject
    {
        // Insert a record into the database
        T Insert(T obj);

        // Update the values held in the database for an existing record
        T Update(T obj);

        // Delete an object by its id
        void Delete(T obj);
    }
}