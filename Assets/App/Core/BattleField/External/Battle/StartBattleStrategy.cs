using System;
using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Common.AssetSystem.Runtime;
using App.Common.Logger.Runtime;
using App.Common.Utilities.Utility.Runtime;
using App.Core.BattleField.External.Path;
using App.Core.BattleField.External.Presenter;
using App.Core.BattleField.Runtime.Config;
using App.Core.BattleField.Runtime.Services;
using App.Core.BattleField.Runtime.Units;
using UnityEngine;

namespace App.Core.BattleField.External.Battle
{
    public class StartBattleStrategy
    {
        private readonly BattleConfigController m_ConfigController;
        private readonly BattleUnitsService m_BattleUnitsService;
        private readonly BattleViewPresenter m_BattleViewPresenter;
        private readonly IAssetManager m_AssetManager;
        
        private event Action<TilePresenter> m_TileClickCallback;

        private PlaceUnitsStrategy m_PlaceUnitsStrategy;

        public StartBattleStrategy(
            BattleUnitsService battleUnitsService, 
            BattleViewPresenter battleViewPresenter, 
            IAssetManager assetManager, 
            BattleConfigController configController,
            Action<TilePresenter> tileClickCallback)
        {
            m_BattleUnitsService = battleUnitsService;
            m_BattleViewPresenter = battleViewPresenter;
            m_AssetManager = assetManager;
            m_ConfigController = configController;
            m_TileClickCallback = tileClickCallback;
        }

        public Optional<Battle> StartBattle(string battleKey)
        {
            m_PlaceUnitsStrategy ??= new PlaceUnitsStrategy(m_BattleViewPresenter, m_ConfigController);
            
            var battleOpt = CreateBattle(battleKey);
            if (!battleOpt.HasValue)
            {
                HLogger.LogError("Failed to create battle: " + battleKey);
                return Optional<Battle>.Fail();
            }
            
            var battle = battleOpt.Value;
            battle.Round = 1;
            
            CreateTiles(battle);
            CreateColliderMatrix(battle);
            CreateUnits(battle);
            PlaceUnits(battle);
            
            return Optional<Battle>.Success(battle);
        }

        private Optional<Battle> CreateBattle(string battleKey)
        {
            var data = new BattleData();
            var config = m_ConfigController.GetBattle(battleKey);
            if (!config.HasValue)
            {
                HLogger.LogError("Battle config not found: " + battleKey);
                return Optional<Battle>.Fail();
            }
            
            var battle = new Battle(config.Value, data);

            return Optional<Battle>.Success(battle);
        }

        private void CreateUnits(Battle battle)
        {
            var battleArmy = m_BattleUnitsService.CreatePlayerBattleArmy();
            battle.Units = new List<BattleUnitPresenter>(battleArmy.Count);
            foreach (var battleUnit in battleArmy)
            {
                var view = CreateView(battleUnit);
                if (!view.HasValue)
                {
                    HLogger.LogError("Failed to create unit view");
                    continue;
                }
                
                var unitPresenter = new BattleUnitPresenter(battleUnit, view.Value);
                battle.Units.Add(unitPresenter);
            }
        }

        private void CreateTiles(Battle battle)
        {
            var view = m_BattleViewPresenter.GetFieldView();
            var width = m_ConfigController.GetWidth();
            var height = m_ConfigController.GetHeight();
            
            battle.Matrix = new Matrix<TilePresenter>(width, height);
            for (int row = 0; row < view.RowViews.Length; ++row)
            {
                var rowView = view.RowViews[row];
                for (int col = 0; col < rowView.TileViews.Length; ++col)
                {
                    var colView = rowView.TileViews[col];
                    var presenter = new TilePresenter(colView, col, row, OnTileClick);
                    presenter.Initialize();
                    battle.Matrix[row, col] = presenter;
                }
            }
        }

        private void PlaceUnits(Battle battle)
        {
            m_PlaceUnitsStrategy.PlaceUnits(battle.Units);
        }

        private void CreateColliderMatrix(Battle battle)
        {
            var width = m_ConfigController.GetWidth();
            var height = m_ConfigController.GetHeight();
            
            battle.CollidersMatrix = new Matrix<int>(width, height);
            battle.CollidersMatrix.Fill(HexagonPathService.Empty);
        }

        private Optional<Transform> CreateView(BattleUnit unit)
        {
            var assetKey = unit.Unit.Unit.Config.Asset;
            var view = m_AssetManager.InstantiateSync<Transform>(new StringKeyEvaluator(assetKey));
            return view;
        }

        private void OnTileClick(TilePresenter presenter)
        {
            m_TileClickCallback?.Invoke(presenter);
        }
    }
}