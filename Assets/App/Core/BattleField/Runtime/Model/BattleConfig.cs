using System.Collections.Generic;
using App.Core.BattleField.Runtime.Dto;

namespace App.Core.BattleField.Runtime.Config
{
    public class BattleConfig
    {
        private readonly int m_Width;
        private readonly int m_Height;
        private readonly int[][] m_UnitPositions;
        private readonly List<BattleInfoConfig> m_Battles;

        public int Width => m_Width;
        public int Height => m_Height;
        public int[][] UnitPositions => m_UnitPositions;
        public IReadOnlyList<BattleInfoConfig> Battles => m_Battles;

        public BattleConfig(BattleDto dto)
        {
            m_Width = dto.Width;
            m_Height = dto.Height;
            m_UnitPositions = dto.UnitPositions;
            m_Battles = new List<BattleInfoConfig>(dto.Battles.Length);
            foreach (var battleDto in dto.Battles)
            {
                m_Battles.Add(new BattleInfoConfig(battleDto));
            }
        }
    }
}
