using System;
using ServiceStack.OrmLite.SqlServer;

namespace LayersCMS.Data.Persistence.DialectProviders
{
    /// <summary>
    /// A <see cref="SqlServerOrmLiteDialectProvider"/> with support for NTEXT where appropriate
    /// </summary>
    public class MsSqlServerOrmLiteDialectProvider : SqlServerOrmLiteDialectProvider
    {
        public override string GetColumnDefinition(string fieldName, Type fieldType, bool isPrimaryKey, bool autoIncrement, bool isNullable, int? fieldLength, int? scale, string defaultValue)
        {
            string defaultColumnDefinition = base.GetColumnDefinition(fieldName, fieldType, isPrimaryKey, autoIncrement, isNullable, fieldLength, scale, defaultValue);

            if (fieldLength.HasValue)
            {
                if (fieldType == typeof(string) && fieldLength > 4000)
                {
                    // NVARCHAR greater than 4000 is not supported so use NTEXT
                    return defaultColumnDefinition.Replace(string.Format(base.StringLengthColumnDefinitionFormat, fieldLength), "NTEXT");
                }
            }

            return defaultColumnDefinition;
        }

    }
}
