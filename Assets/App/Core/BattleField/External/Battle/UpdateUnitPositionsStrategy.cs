using System.Collections;
using App.Common.Utilities.External;
using App.Core.BattleField.External.Presenter;
using App.Core.BattleField.Runtime.Config;
using UnityEngine;

namespace App.Core.BattleField.External.Battle
{
    public class UpdateUnitPositionsStrategy
    {
        private readonly BattleConfigController m_ConfigController;  
        private readonly BattleViewPresenter m_BattleViewPresenter;

        public UpdateUnitPositionsStrategy(
            BattleViewPresenter battleViewPresenter, 
            BattleConfigController configController)
        {
            m_BattleViewPresenter = battleViewPresenter;
            m_ConfigController = configController;
        }

        public void Initialize()
        {
        }

        public void PlaceUnits(Battle battle)
        {
            GlobalCoroutineProvider.DoCoroutine(UpdateUnitPositions(battle));
        }

        private IEnumerator UpdateUnitPositions(Battle battle)
        {
            yield return new WaitForEndOfFrame();
            foreach (var unit in battle.Units)
            {
                UpdateUnitPosition(unit);
            }

            foreach (var unit in battle.EnemyUnits)
            {
                UpdateUnitPosition(unit);
            }
        }

        public void UpdateUnitPosition(BattleUnitPresenter unit)
        {
            var position = unit.Position;
            unit.View.transform.position = m_BattleViewPresenter.GetPositionForUnit(position.Y, position.X);
        }
    }
}