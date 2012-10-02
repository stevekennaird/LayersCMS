using QuickWin.Cms.Data.Domain;

namespace QuickWin.Cms.Data.Persistence.Interfaces.Reads.Base
{
    public interface IQuickWinReads<T> where T : QuickWinDomainObject
    {
        T GetById(int id);
    }
}