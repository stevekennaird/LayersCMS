using LayersCMS.Data.Domain.Core.Settings;
using LayersCMS.Data.Persistence.Implementations.Writes.Base;
using LayersCMS.Data.Persistence.Interfaces.Writes;
using ServiceStack.OrmLite;
using System.Data;

namespace LayersCMS.Data.Persistence.Implementations.Writes
{
    public class LayersCmsSettingWrites : LayersCmsWrites<LayersCmsSetting>, ILayersCmsSettingWrites
    {
        #region Implementation of ILayersCmsSettingWrites

        public void InsertOrUpdateByType(LayersCmsSettingType settingType, string value)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                // Search for an existing setting with a matching SettingTypeId
                var existingSetting = conn.Single<LayersCmsSetting>("SettingTypeId = {0}", (int) settingType);
                
                if (existingSetting == null)
                {
                    // No value found, insert a new row
                    conn.Insert(new LayersCmsSetting()
                        {
                            SettingType = settingType,
                            Value = value
                        });
                }
                else
                {
                    // Value found, update the existing row
                    existingSetting.Value = value;
                    conn.Update(existingSetting);
                }
            }
        }

        #endregion
    }
}
