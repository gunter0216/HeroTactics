using System.Collections;
using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Common.AssetSystem.Runtime;
using App.Common.Utilities.External;
using App.Common.Utilities.Utility.Runtime;
using App.Core.BattleField.External.Path;
using App.Core.BattleField.External.Presenter;
using App.Core.BattleField.Runtime.Config;
using App.Core.BattleField.Runtime.Services;
using App.Core.BattleField.Runtime.Units;
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

        private List<BattleUnitPresenter> m_Units;
        private Matrix<TilePresenter> m_Matrix;
        private Matrix<int> m_CollidersMatrix;
        private HexagonPathService m_HexagonPathService = new();
        
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
            var view = m_BattleViewPresenter.GetFieldView();
            var width = m_ConfigController.GetWidth();
            var height = m_ConfigController.GetHeight();
            m_Matrix = new Matrix<TilePresenter>(width, height);
            for (int row = 0; row < view.RowViews.Length; ++row)
            {
                var rowView = view.RowViews[row];
                for (int col = 0; col < rowView.TileViews.Length; ++col)
                {
                    var colView = rowView.TileViews[col];
                    var presenter = new TilePresenter(colView, col, row, OnTileClick);
                    presenter.Initialize();
                    m_Matrix[row, col] = presenter;
                }
            }
            
            m_CollidersMatrix = new Matrix<int>(width, height);
            m_CollidersMatrix.Fill(HexagonPathService.Empty);
        }

        private void OnTileClick(TilePresenter presenter)
        {
            // todo
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

            PlaceUnits();
            
            GlobalCoroutineProvider.DoCoroutine(UpdateUnitPositions());

            TestMatrix();
        }

        private void PlaceUnits()
        {
            var positions = m_ConfigController.GetUnitPositions(m_Units.Count);
            m_Units.Sort((x, y) => x.Unit.Unit.Position.CompareTo(y.Unit.Unit.Position));
            for (int i = 0; i < m_Units.Count; ++i)
            {
                var unit = m_Units[i];
                var col = positions[i];
                unit.Position = new Vector2Int(2, col);
            }
        }

        private void TestMatrix()
        {
            var colliderMatrix = CreateCollidersMatrix();
            var liMatrixOpt = m_HexagonPathService.CreateLiMatrix(colliderMatrix, new Vector2Int(2, 2), 10);
            if (!liMatrixOpt.HasValue)
            {
                Debug.LogError("Failed to create li matrix");
                return;
            }

            var liMatrix = liMatrixOpt.Value;
            for (int row = 0; row < liMatrix.Height; ++row)
            {
                for (int col = 0; col < liMatrix.Width; ++col)
                {
                    var cellValue = liMatrix[row, col];
                    var tile = m_Matrix[row, col];
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
            var matrix = new Matrix<int>(m_Matrix.Width, m_Matrix.Height);
            matrix.Fill(HexagonPathService.Empty);
            foreach (var unit in m_Units)
            {
                var pos = unit.Position;
                matrix[pos.Y, pos.X] = HexagonPathService.Wall;
            }
            
            return matrix;
        }

        private IEnumerator UpdateUnitPositions()
        {
            yield return new WaitForEndOfFrame();
            for (int i = 0; i < m_Units.Count; ++i)
            {
                var unit = m_Units[i];
                var position = unit.Position;
                unit.View.transform.position = m_BattleViewPresenter.GetPositionForUnit(position.Y, position.X);
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