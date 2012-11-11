using System;
using LayersCMS.Data.Domain.Core.Settings;
using LayersCMS.Data.Persistence.Interfaces.Reads.Base;

namespace LayersCMS.Data.Persistence.Interfaces.Reads
{
    public interface ILayersCmsSettingReads : ILayersCmsReads<LayersCmsSetting>
    {
        LayersCmsSetting GetForSettingType(LayersCmsSettingType settingType);
        String GetStringValueForSettingType(LayersCmsSettingType settingType);
        Int32 GetIntegerValueForSettingType(LayersCmsSettingType settingType);
        Decimal GetDecimalValueForSettingType(LayersCmsSettingType settingType);
    }
}