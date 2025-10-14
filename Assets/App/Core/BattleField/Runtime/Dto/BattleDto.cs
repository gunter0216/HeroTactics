using System;
using Newtonsoft.Json;

namespace App.Core.BattleField.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class BattleDto
    {
        [JsonProperty("key")] private string m_Key;
        [JsonProperty("units")] private BattleUnitDto[] m_Units;
            
        public string Key => m_Key;
        public BattleUnitDto[] Units => m_Units;
    } 
}

