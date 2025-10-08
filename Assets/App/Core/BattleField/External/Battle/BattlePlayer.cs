using System.Collections;
using System.Collections.Generic;
using App.Battle.UI.External.Presenter;
using App.Common.Algorithms.Matrix;
using App.Common.AssetSystem.Runtime;
using App.Common.Utilities.External;
using App.Common.Utilities.Utility.Runtime;
using App.Core.BattleField.Runtime.Config;
using App.Core.BattleField.Runtime.Services;
using App.Core.BattleField.Runtime.Units;
using UnityEngine;

namespace App.Menu.UI.External
{
    public class BattlePlayer
    {
        private readonly BattleConfigController m_ConfigController;  
        private readonly BattleUnitsService m_BattleUnitsService;
        private readonly BattleViewPresenter m_BattleViewPresenter;
        private readonly IAssetManager m_AssetManager;

        private List<BattleUnitPresenter> m_Units;
        private Matrix<BattleFieldCell> m_Matrix;
        
        public BattlePlayer(
            BattleUnitsService battleUnitsService, 
            BattleViewPresenter battleViewPresenter, 
            IAssetManager assetManager, 
            BattleConfigController configController)
        {
            m_BattleUnitsService = battleUnitsService;
            m_BattleViewPresenter = battleViewPresenter;
            m_AssetManager = assetManager;
            m_ConfigController = configController;
        }

        public void Initialize()
        {
            var width = m_ConfigController.GetWidth();
            var height = m_ConfigController.GetHeight();
            m_Matrix = new Matrix<BattleFieldCell>(width, height);
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    m_Matrix[y, x] = new BattleFieldCell(y, x);
                }
            }
        }

        public void StartBattle()
        {
            var battleArmy = m_BattleUnitsService.CreatePlayerBattleArmy();
            m_Units = new List<BattleUnitPresenter>(battleArmy.Count);
            foreach (var battleUnit in battleArmy)
            {
                var view = CreateView(battleUnit);
                if (!view.HasValue)
                {
                    Debug.LogError("Failed to create unit view");
                    continue;
                }
                
                var unitPresenter = new BattleUnitPresenter(battleUnit, view.Value);
                m_Units.Add(unitPresenter);
            }
            
            GlobalCoroutineProvider.DoCoroutine(UpdateUnitPositions());
        }

        private IEnumerator UpdateUnitPositions()
        {
            yield return new WaitForEndOfFrame();
            var positions = m_ConfigController.GetUnitPositions(m_Units.Count);
            m_Units.Sort((x, y) => x.Unit.Unit.Position.CompareTo(y.Unit.Unit.Position));
            for (int i = 0; i < m_Units.Count; ++i)
            {
                var unit = m_Units[i];
                var col = positions[i];
                unit.View.transform.position = m_BattleViewPresenter.GetPositionForUnit(col, 0);
            }
        }

        public Optional<Transform> CreateView(BattleUnit unit)
        {
            var assetKey = unit.Unit.Unit.Config.Asset;
            var view = m_AssetManager.InstantiateSync<Transform>(new StringKeyEvaluator(assetKey));
            return view;
        }
    }
}