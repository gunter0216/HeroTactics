using System.Collections;
using System.Collections.Generic;
using App.Common.Utilities.External;
using App.Core.BattleField.External.Presenter;
using App.Core.BattleField.Runtime.Config;
using UnityEngine;
using Vector2Int = App.Common.Algorithms.Runtime.Vector2Int;

namespace App.Core.BattleField.External.Battle
{
    public class PlaceUnitsStrategy
    {
        private readonly BattleConfigController m_ConfigController;  
        private readonly BattleViewPresenter m_BattleViewPresenter;

        public PlaceUnitsStrategy(
            BattleViewPresenter battleViewPresenter, 
            BattleConfigController configController)
        {
            m_BattleViewPresenter = battleViewPresenter;
            m_ConfigController = configController;
        }

        public void Initialize()
        {
        }

        public void PlaceUnits(IReadOnlyList<BattleUnitPresenter> units)
        {
            var positions = m_ConfigController.GetUnitPositions(units.Count);
            for (int i = 0; i < units.Count; ++i)
            {
                var unit = units[i];
                var col = positions[i];
                unit.Position = new Vector2Int(2, col);
            }

            GlobalCoroutineProvider.DoCoroutine(UpdateUnitPositions(units));
        }

        private IEnumerator UpdateUnitPositions(IReadOnlyList<BattleUnitPresenter> units)
        {
            yield return new WaitForEndOfFrame();
            foreach (var unit in units)
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