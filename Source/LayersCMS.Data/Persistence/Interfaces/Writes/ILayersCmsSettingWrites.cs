using System;
using LayersCMS.Data.Domain.Core.Settings;
using LayersCMS.Data.Persistence.Interfaces.Writes.Base;

namespace LayersCMS.Data.Persistence.Interfaces.Writes
{
    public interface ILayersCmsSettingWrites : ILayersCmsWrites<LayersCmsSetting>
    {
        void InsertOrUpdateByType(LayersCmsSettingType settingType, String value);
    }
}