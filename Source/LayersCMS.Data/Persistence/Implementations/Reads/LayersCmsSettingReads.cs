using System;
using LayersCMS.Data.Domain.Core.Settings;
using LayersCMS.Data.Persistence.Implementations.Reads.Base;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using ServiceStack.OrmLite;
using System.Data;

namespace LayersCMS.Data.Persistence.Implementations.Reads
{
    public class LayersCmsSettingReads : LayersCmsReads<LayersCmsSetting>, ILayersCmsSettingReads
    {
        #region Implementation of ILayersCmsSettingReads

        public LayersCmsSetting GetForSettingType(LayersCmsSettingType settingType)
        {
            using (IDbConnection conn = GetDbConnection())
            {
                return conn.Single<LayersCmsSetting>("SettingTypeId = {0}", (int)settingType);
            }
        }

        public String GetStringValueForSettingType(LayersCmsSettingType settingType)
        {
            LayersCmsSetting setting = GetForSettingType(settingType);

            // If no setting is found, return a default value
            if (setting == null)
                return null;

            return setting.GetValueAsString();
        }

        public Int32 GetIntegerValueForSettingType(LayersCmsSettingType settingType)
        {
            LayersCmsSetting setting = GetForSettingType(settingType);

            // If no setting is found, return a default value
            if (setting == null)
                return default(Int32);

            return setting.GetValueAsInteger();
        }

        public Decimal GetDecimalValueForSettingType(LayersCmsSettingType settingType)
        {
            LayersCmsSetting setting = GetForSettingType(settingType);

            // If no setting is found, return a default value
            if (setting == null)
                return default(Decimal);

            return setting.GetValueAsDecimal();
        }

        #endregion
    }
}
