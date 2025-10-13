using System;
using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Common.Algorithms.Runtime;
using App.Common.Utilities.Utility.Runtime;

namespace App.Core.BattleField.External.Path
{
    public class HexagonPathFinder
    {
        private Matrix<int> m_Matrix;
        private Vector2Int m_To;
        private Vector2Int m_From;
        private HexagonInfo m_HexagonInfo;

        public HexagonPathFinder(HexagonInfo hexagonInfo)
        {
            m_HexagonInfo = hexagonInfo;
        }

        public Optional<List<Vector2Int>> BuildPath(
            Matrix<int> matrix, 
            Vector2Int from, 
            Vector2Int to)
        {
            m_Matrix = matrix;
            m_From = from;
            m_To = to;

            List<Vector2Int> buildPath = new List<Vector2Int> { m_To };
            Vector2Int currentPos = m_To;
            m_Matrix.SetCell(m_To, Int32.MaxValue);
            for (int i = 0; i < 100; ++i)
            {
                if (currentPos == m_From)
                {
                    break;
                }
                
                currentPos = GetCellWithMinValueAround(currentPos);
                if (currentPos.X == -1 && currentPos.Y == -1)
                {
                    return Optional<List<Vector2Int>>.Fail();
                }

                buildPath.Add(currentPos);
            }

            return new Optional<List<Vector2Int>>(buildPath);
        }

        private Vector2Int GetCellWithMinValueAround(Vector2Int pos)
        {
            var cellWithMinValue = new Vector2Int(-1, -1);
            int minValue = m_Matrix.GetCell(pos);
            foreach (var offset in m_HexagonInfo.GetOffsets(pos.Y))
            {
                var newPos = pos + offset;
                if (m_Matrix.IsCorrectPos(newPos))
                {
                    var cellValue = m_Matrix.GetCell(newPos);
                    if (cellValue < 0)
                    {
                        continue;
                    }
                    
                    if (cellValue < minValue)
                    {
                        minValue = cellValue;
                        cellWithMinValue = newPos;
                    }
                }
            }

            return cellWithMinValue;
        }
    }
}