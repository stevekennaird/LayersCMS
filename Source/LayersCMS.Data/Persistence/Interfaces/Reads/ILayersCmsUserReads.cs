using LayersCMS.Data.Domain.Security;
using LayersCMS.Data.Persistence.Interfaces.Reads.Base;

namespace LayersCMS.Data.Persistence.Interfaces.Reads
{
    public interface ILayersCmsUserReads : ILayersCmsReads<LayersCmsUser>
    {
        LayersCmsUser GetForLogin(string emailAddress, string plainTextPassword);
    }
}