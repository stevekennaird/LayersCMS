using System.Collections.Generic;
using LayersCMS.Data.Domain;

namespace LayersCMS.Data.Persistence.Interfaces.Reads.Base
{
    public interface ILayersCmsReads<T> where T : LayersCmsDomainObject
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}