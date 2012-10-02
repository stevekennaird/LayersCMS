using QuickWin.Cms.Data.Domain.Pages;
using QuickWin.Cms.Data.Persistence.Interfaces.Reads.Base;

namespace QuickWin.Cms.Data.Persistence.Interfaces.Reads
{
    public interface IQuickWinPageReads : IQuickWinReads<QuickWinPage>
    {
        QuickWinPage GetByUrl(string url, bool publishedOnly);
    }
}