using System;
using ServiceStack.OrmLite;

namespace LayersCMS.Data.Persistence.Setup
{
    public class DatabaseSetupConfig
    {
        public IOrmLiteDialectProvider DatabaseDialect { get; set; }
        public String ConnectionStringName { get; set; }
        public String UserEmailAddress { get; set; }
        public String UserPassword { get; set; } // This should be encrypted

    }
}
