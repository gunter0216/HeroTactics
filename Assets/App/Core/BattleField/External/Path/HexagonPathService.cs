using System.Collections.Generic;
using App.Common.Algorithms.Matrix;
using App.Common.Algorithms.Runtime;
using App.Common.Utilities.Utility.Runtime;

namespace App.Core.BattleField.External.Path
{
    public class HexagonPathService
    {
        private readonly Vector2Int[] m_OddOffsets =
        {
            new Vector2Int( -1, 0 ), 
            new Vector2Int( -1, -1 ), 
            new Vector2Int( 0, -1 ), 
            new Vector2Int( 1, 0 ), 
            new Vector2Int( -1, 1 ), 
            new Vector2Int( 0, 1 )
        };
        
        private readonly Vector2Int[] m_EvenOffsets =
        {
            new Vector2Int( -1, 0 ), 
            new Vector2Int( 0, -1 ), 
            new Vector2Int( 1, -1 ), 
            new Vector2Int( 1, 0 ), 
            new Vector2Int( 0, 1 ), 
            new Vector2Int( 1, 1 )
        };
        
        public const int Empty = -1;
        public const int Wall = -2;

        private Matrix<int> m_Matrix;
        private List<Vector2Int> m_ActiveCells;

        public HexagonPathService()
        {
            m_ActiveCells = new List<Vector2Int>(10);
            // m_PathFinderMatrixCreator = new PathFinderMatrixCreator(
            //     wall, 
            //     empty, 
            //     horizontalWall, 
            //     verticalWall);
            // m_PathBuilder = new PathBuilder();
        }

        public Optional<Matrix<int>> CreateLiMatrix(Matrix<int> collidersMatrix, Vector2Int from, int range)
        {
            // if (m_Matrix == null ||
            //     m_Matrix.Width != collidersMatrix.Width ||
            //     m_Matrix.Height != collidersMatrix.Height)
            // {
            //     m_Matrix = new Matrix<int>(collidersMatrix.Width, collidersMatrix.Height);
            // }

            m_Matrix = new Matrix<int>(collidersMatrix);
            
            m_Matrix.SetCell(from.Y, from.X, 0);
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
                var offsets = (activeCell.Y % 2 == 0) ? m_EvenOffsets : m_OddOffsets;
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
                    if (value != Empty)
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

        // public Optional<List<Position>> FindPath(
        //     Matrix inputMatrix,
        //     Position from,
        //     Position to)
        // {
        //     m_From = from;
        //     m_To = to;
        //     m_Matrix = new Matrix(inputMatrix);
        //
        //     if (!IsCorrectMatrix(inputMatrix))
        //     {
        //         return Optional<List<Position>>.Fail();
        //     }
        //
        //     return Optional<List<Position>>.Fail();
        //     // m_PathFinderMatrixCreator.PreCalc(m_Matrix, m_From, m_To);
        //     // return m_PathBuilder.BuildPath(m_Matrix, m_From, m_To, m_InputCellValues);
        // }
    }
}