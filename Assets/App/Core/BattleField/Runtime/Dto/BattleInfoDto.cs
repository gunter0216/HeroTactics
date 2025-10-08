using System;
using Newtonsoft.Json;

namespace App.Core.BattleField.Runtime.Config
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class BattleInfoDto
    {
        [JsonProperty("key")] private string m_Key;
            
        public string Key => m_Key;
    } 
}

