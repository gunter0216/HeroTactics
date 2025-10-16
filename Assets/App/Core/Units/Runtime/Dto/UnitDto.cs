using System;
using Newtonsoft.Json;

namespace App.Core.Units.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class UnitDto
    {
        [JsonProperty("key")] private string m_Key;
        [JsonProperty("asset")] private string m_Asset;
        [JsonProperty("initiative")] private int m_Initiative;
        [JsonProperty("attack")] private int m_Attack;
        [JsonProperty("speed")] private int m_Speed;
        [JsonProperty("health")] private int m_Health;
        [JsonProperty("damage")] private int m_Damage;
        [JsonProperty("armor")] private int m_Armor;
        [JsonProperty("icon_key")] private string m_IconKey;

        public string Key => m_Key;
        public string Asset => m_Asset;
        public int Initiative => m_Initiative;
        public int Attack => m_Attack;
        public int Speed => m_Speed;
        public int Health => m_Health;
        public int Damage => m_Damage;
        public int Armor => m_Armor;
        public string IconKey => m_IconKey;
    }
}