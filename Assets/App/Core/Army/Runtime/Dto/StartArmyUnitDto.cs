using System;
using Newtonsoft.Json;

namespace App.Core.Army.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class StartArmyUnitDto
    {
        [JsonProperty("key")] private string m_Key;

        public string Key => m_Key;
    }
}