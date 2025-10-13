using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Common.Algorithms.Runtime;
using App.Common.Utilities.Utility.Runtime;

namespace App.Core.BattleField.External.Path
{
    public class HexagonPathService
    {
        public const int Empty = -1;
        public const int Wall = -2;

        private readonly HexagonInfo m_HexagonInfo = new();
        private readonly HexagonPathFinder m_PathFinder;
        private readonly HexagonLiMatrixCreator m_LiMatrixCreator;
        
        public HexagonPathService()
        {
            m_LiMatrixCreator = new HexagonLiMatrixCreator(m_HexagonInfo);
            m_PathFinder = new HexagonPathFinder(m_HexagonInfo);
        }

        public Optional<Matrix<int>> CreateLiMatrix(Matrix<int> collidersMatrix, Vector2Int from, int range)
        {
            return m_LiMatrixCreator.CreateLiMatrix(collidersMatrix, from, range);
        }

        public Optional<List<Vector2Int>> BuildPath(
            Matrix<int> matrix,
            Vector2Int from,
            Vector2Int to)
        {
            return m_PathFinder.BuildPath(matrix, from, to);
        }
    }
}