using System.Collections.Generic;
using System.Linq;
using App.Core.BattleField.External.Presenter;

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
            // капец тут выделения памяти, потом переписать бы
            var playerUnits = m_Battle.Units;
            var enemyUnits = m_Battle.EnemyUnits;

            // Группируем по initiative
            var playerGroups = playerUnits.GroupBy(u => u.Unit.Config.Initiative)
                .ToDictionary(g => g.Key, g => g.ToList());
            var enemyGroups = enemyUnits.GroupBy(u => u.Unit.Config.Initiative)
                .ToDictionary(g => g.Key, g => g.ToList());

            var allInitiatives = playerGroups.Keys.Union(enemyGroups.Keys)
                .OrderByDescending(i => i);

            var roundUnits = new List<BattleUnitPresenter>();

            foreach (var initiative in allInitiatives)
            {
                playerGroups.TryGetValue(initiative, out var pList);
                enemyGroups.TryGetValue(initiative, out var eList);
                pList = pList ?? new List<BattleUnitPresenter>();
                eList = eList ?? new List<BattleUnitPresenter>();

                int p = 0, e = 0;
                while (p < pList.Count || e < eList.Count)
                {
                    if (p < pList.Count)
                    {
                        roundUnits.Add(pList[p]);
                        p++;
                    }
                    if (e < eList.Count)
                    {
                        roundUnits.Add(eList[e]);
                        e++;
                    }
                }
            }

            m_Battle.RoundUnits = roundUnits;
        }
    }
}