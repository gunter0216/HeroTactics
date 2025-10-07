using System;
using Newtonsoft.Json;

namespace App.Core.Army.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class ArmyDto
    {
        [JsonProperty("start_army")] private StartArmyUnitDto[] m_StartArmy;
        [JsonProperty("max_army")] private int m_MaxArmy;
        
        public StartArmyUnitDto[] StartArmy => m_StartArmy;
        public int MaxArmy => m_MaxArmy;
    }
}