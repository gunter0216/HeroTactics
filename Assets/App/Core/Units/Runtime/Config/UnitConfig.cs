using App.Core.Units.Runtime.Dto;

namespace App.Core.Units.Runtime.Config
{
    public class UnitConfig
    {
        private readonly string m_Key;
        private readonly string m_Asset;

        public string Key => m_Key;
        public string Asset => m_Asset;
        
        public UnitConfig(UnitDto unitDto)
        {
            m_Key = unitDto.Key;
            m_Asset = unitDto.Asset;
        }
    }
}