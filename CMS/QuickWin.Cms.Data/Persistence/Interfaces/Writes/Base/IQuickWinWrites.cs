using QuickWin.Cms.Data.Domain;

namespace QuickWin.Cms.Data.Persistence.Interfaces.Writes.Base
{
    public interface IQuickWinWrites<T> where T : QuickWinDomainObject
    {
        T Insert(T obj);
    }
}