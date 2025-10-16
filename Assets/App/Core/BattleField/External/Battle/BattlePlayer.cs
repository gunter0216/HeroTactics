using System.Linq;
using App.Common.Algorithms.Matrix;
using App.Common.AssetSystem.Runtime;
using App.Common.Logger.Runtime;
using App.Core.BattleField.External.Path;
using App.Core.BattleField.External.Presenter;
using App.Core.BattleField.Runtime.Config;
using App.Core.BattleField.Runtime.Services;
using UnityEngine;
using Vector2Int = App.Common.Algorithms.Runtime.Vector2Int;

namespace App.Core.BattleField.External.Battle
{
    public class BattlePlayer
    {
        private readonly BattleConfigController m_ConfigController;  
        private readonly BattleUnitsService m_BattleUnitsService;
        private readonly BattleViewPresenter m_BattleViewPresenter;
        private readonly IAssetManager m_AssetManager;

        private UpdateUnitPositionsStrategy m_UpdateUnitPositionsStrategy;
        private HexagonPathService m_HexagonPathService;
        private StartBattleStrategy m_StartBattleStrategy;
        private RoundUnitsService m_RoundUnitsService;

        private Battle m_Battle;

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
            m_UpdateUnitPositionsStrategy = new UpdateUnitPositionsStrategy(m_BattleViewPresenter, m_ConfigController);
            m_HexagonPathService = new HexagonPathService();
            m_StartBattleStrategy = new StartBattleStrategy(
                m_BattleUnitsService, 
                m_BattleViewPresenter,
                m_AssetManager,
                m_ConfigController,
                OnTileClick);
        }

        public void StartBattle(string battleKey)
        {
            var battle = m_StartBattleStrategy.StartBattle(battleKey);
            if (!battle.HasValue)
            {
                HLogger.LogError("Failed to start battle: " + battleKey);
                return;
            }
            
            m_Battle = battle.Value;
            
            m_RoundUnitsService = new RoundUnitsService(m_Battle);
            PlayBattle();

            // TestMatrix();
        }

        private void PlayBattle()
        {
            m_RoundUnitsService.PrepareRoundUnits();
            NextRound();
            
            TestMatrix();
        }

        private void NextRound()
        {
            m_Battle.Round += 1;
            var units = m_Battle.RoundUnits;
            m_BattleViewPresenter.ShowRoundUnits(units);
        }

        private void OnTileClick(TilePresenter presenter)
        {
            var unit = m_Battle.Units.First();
            var to = new Vector2Int(presenter.X, presenter.Y);
            var path = m_HexagonPathService.BuildPath(m_Battle.LiMatrix, unit.Position, to);
            if (!path.HasValue)
            {
                HLogger.LogError("Failed to build path");
                return;
            }
            
            unit.Position = to;
            m_UpdateUnitPositionsStrategy.UpdateUnitPosition(unit);
            TestMatrix();
        }

        private void TestMatrix()
        {
            var colliderMatrix = CreateCollidersMatrix();
            var unit = m_Battle.Units.First();
            var liMatrixOpt = m_HexagonPathService.CreateLiMatrix(colliderMatrix, unit.Position, 5);
            if (!liMatrixOpt.HasValue)
            {
                Debug.LogError("Failed to create li matrix");
                return;
            }

            m_Battle.LiMatrix = liMatrixOpt.Value;
            for (int row = 0; row < m_Battle.LiMatrix.Height; ++row)
            {
                for (int col = 0; col < m_Battle.LiMatrix.Width; ++col)
                {
                    var cellValue = m_Battle.LiMatrix[row, col];
                    var tile = m_Battle.Matrix[row, col];
                    if (cellValue <= 0)
                    {
                        tile.StayDefault();
                    }
                    else
                    {
                        tile.StayLight();
                    }
                }
            }
        }

        private Matrix<int> CreateCollidersMatrix()
        {
            var matrix = new Matrix<int>(m_Battle.Matrix.Width, m_Battle.Matrix.Height);
            matrix.Fill(HexagonPathService.Empty);
            foreach (var unit in m_Battle.Units)
            {
                var pos = unit.Position;
                matrix[pos.Y, pos.X] = HexagonPathService.Wall;
            }
            
            foreach (var unit in m_Battle.EnemyUnits)
            {
                var pos = unit.Position;
                matrix[pos.Y, pos.X] = HexagonPathService.Wall;
            }
            
            return matrix;
        }
    }
}