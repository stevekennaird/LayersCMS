using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.Data.Domain.Core.Settings
{
    public class LayersCmsSetting : LayersCmsDomainObject
    {
        #region Properties

        [Index(Unique = true)]
        public virtual Int32 SettingTypeId { get; set; }

        [StringLength(400)]
        public virtual String Value { get; set; }

        [Ignore]
        public virtual LayersCmsSettingType SettingType
        {
            get { return (LayersCmsSettingType)SettingTypeId; }
            set { SettingTypeId = (int)value; }
        }

        #endregion

        #region Public Methods

        public Int32 GetValueAsInteger()
        {
            Int32 output;
            if (Int32.TryParse(Value, out output))
            {
                return output;
            }
            return default(Int32);
        }

        public Decimal GetValueAsDecimal()
        {
            Decimal output;
            if (Decimal.TryParse(Value, out output))
            {
                return output;
            }
            return default(Decimal);
        }

        public String GetValueAsString()
        {
            // Value is already a String, this is included for completeness
            return Value;
        }

        #endregion


    }
}
