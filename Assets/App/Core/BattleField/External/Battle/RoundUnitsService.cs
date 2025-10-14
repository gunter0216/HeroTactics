namespace App.Core.BattleField.External.Battle
{
    public class RoundUnitsService
    {
        private readonly Battle m_Battle;

        public RoundUnitsService(Battle battle)
        {
            m_Battle = battle;
        }

        public void PrepareRoundUnits()
        {
            // var roundUnits = m_Battle.Units.FindAll(unit => unit.IsAlive);
            // m_Battle.RoundUnits = roundUnits;
        }
    }
}