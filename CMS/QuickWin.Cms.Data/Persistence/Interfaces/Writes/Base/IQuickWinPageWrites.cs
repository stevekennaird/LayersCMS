using QuickWin.Cms.Data.Domain.Pages;

namespace QuickWin.Cms.Data.Persistence.Interfaces.Writes.Base
{
    public interface IQuickWinPageWrites : IQuickWinWrites<QuickWinPage>
    {
        QuickWinPage Update(int id);
    }
}