using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Common.Algorithms.Runtime;
using App.Common.Utilities.Utility.Runtime;

namespace App.Core.BattleField.External.Path
{
    public class HexagonLiMatrixCreator
    {
        private readonly HexagonInfo m_HexagonInfo;
        
        private Matrix<int> m_Matrix;
        private List<Vector2Int> m_ActiveCells;

        public HexagonLiMatrixCreator(HexagonInfo hexagonInfo)
        {
            m_HexagonInfo = hexagonInfo;
            m_ActiveCells = new List<Vector2Int>(10);
        }

        public Optional<Matrix<int>> CreateLiMatrix(Matrix<int> collidersMatrix, Vector2Int from, int range)
        {
            m_Matrix = new Matrix<int>(collidersMatrix);
            
            m_Matrix.SetCell(from.Y, from.X, 0);
            m_ActiveCells.Clear();
            m_ActiveCells.Add(from);
            for (int i = 0; i < 100; ++i)
            {
                if (m_ActiveCells.Count <= 0)
                {
                    break;
                }
                
                NextIteration(range);
            }
            
            return Optional<Matrix<int>>.Success(new Matrix<int>(m_Matrix));
        }

        private void NextIteration(int range)
        {
            var newActiveCells = new List<Vector2Int>(m_ActiveCells.Capacity);
            foreach (var activeCell in m_ActiveCells)
            {
                var offsets = m_HexagonInfo.GetOffsets(activeCell.Y);
                foreach (var offset in offsets)
                {
                    var newPos = activeCell + offset;
                    var row = newPos.Y;
                    var col = newPos.X;
                    if (!m_Matrix.IsCorrectPos(row, col))
                    {
                        continue;
                    }

                    var value = m_Matrix.GetCell(row, col);
                    if (value != HexagonPathService.Empty)
                    {
                        continue;
                    }
                    
                    var prevValue = m_Matrix.GetCell(activeCell.Y, activeCell.X);
                    var newValue = prevValue + 1;
                    m_Matrix.SetCell(row, col, newValue);
                    if (newValue < range)
                    {
                        newActiveCells.Add(newPos);
                    }
                }
            }
            
            m_ActiveCells = newActiveCells;
        }
    }
}