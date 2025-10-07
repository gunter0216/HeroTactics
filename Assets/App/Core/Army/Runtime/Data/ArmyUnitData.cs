using System;
using App.Common.DataContainer.Runtime;
using Newtonsoft.Json;

namespace App.Core.Army.Runtime.Data
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class ArmyUnitData
    {
        [JsonProperty("reference")] 
        private DataReference m_Reference;

        public DataReference Reference
        {
            get => m_Reference;
            set => m_Reference = value;
        }
    }
}