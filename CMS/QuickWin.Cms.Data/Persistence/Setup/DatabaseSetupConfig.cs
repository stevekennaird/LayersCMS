using System;

namespace QuickWin.Cms.Data.Persistence.Setup
{
    public class DatabaseSetupConfig
    {
        public String UserEmailAddress { get; set; }
        public String UserPassword { get; set; } // This should be encrypted

    }
}
