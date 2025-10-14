using App.Core.Units.Runtime.Dto;

namespace App.Core.Units.Runtime.Config
{
    public class UnitConfig
    {
        private readonly string m_Key;
        private readonly string m_Asset;
        private readonly int m_Priority;
        private readonly int m_Attack;
        private readonly int m_Speed;
        private readonly int m_Health;
        private readonly int m_Damage;
        private readonly int m_Armor;

        public string Key => m_Key;
        public string Asset => m_Asset;
        public int Priority => m_Priority;
        public int Attack => m_Attack;
        public int Speed => m_Speed;
        public int Health => m_Health;
        public int Damage => m_Damage;
        public int Armor => m_Armor;

        public UnitConfig(UnitDto unitDto)
        {
            m_Key = unitDto.Key;
            m_Asset = unitDto.Asset;
            m_Priority = unitDto.Priority;
            m_Attack = unitDto.Attack;
            m_Speed = unitDto.Speed;
            m_Health = unitDto.Health;
            m_Damage = unitDto.Damage;
            m_Armor = unitDto.Armor;
        }
    }
}