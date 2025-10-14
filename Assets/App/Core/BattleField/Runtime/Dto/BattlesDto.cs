using System;
using Newtonsoft.Json;

namespace App.Core.BattleField.Runtime.Dto
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class BattlesDto
    {
        [JsonProperty("width")] private int m_Width;
        [JsonProperty("height")] private int m_Height;
        [JsonProperty("unit_positions")] private int[][] m_UnitPositions;
        [JsonProperty("battles")] private BattleDto[] m_Battles;

        public int Width => m_Width;
        public int Height => m_Height;
        public BattleDto[] Battles => m_Battles;
        public int[][] UnitPositions => m_UnitPositions;
    }
}
