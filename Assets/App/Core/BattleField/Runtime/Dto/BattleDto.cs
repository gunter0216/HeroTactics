
using System;
using App.Core.BattleField.Runtime.Config;
using Newtonsoft.Json;

namespace App.Core.BattleField.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class BattleDto
    {
        [JsonProperty("width")] private int m_Width;
        [JsonProperty("height")] private int m_Height;
        [JsonProperty("battles")] private BattleInfoDto[] m_Battles;

        public int Width => m_Width;
        public int Height => m_Height;
        public BattleInfoDto[] Battles => m_Battles;
    }
}
