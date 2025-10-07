using System;
using System.Collections.Generic;
using App.Common.Data.Runtime;
using Newtonsoft.Json;

namespace App.Core.Army.Runtime.Data
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class ArmyData : IData
    {
        public const string DataName = nameof(ArmyData);
        
        [JsonProperty("army")] 
        private ArmyUnitData[] m_Army;

        public ArmyUnitData[] Army
        {
            get => m_Army;
            set => m_Army = value;
        }

        public string Name()
        {
            return DataName;
        }
    }
}