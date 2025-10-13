using App.Common.Algorithms.Runtime;

namespace App.Common.Algorithms.Matrix
{
    public static class MatrixExtension
    {
        public static void SetCell<T>(this Matrix<T> matrix, Vector2Int pos, T value)
        {
            matrix.SetCell(pos.Y, pos.X, value);
        }
        
        public static T GetCell<T>(this Matrix<T> matrix, Vector2Int pos)
        {
            return matrix.GetCell(pos.Y, pos.X);
        }
        
        public static bool IsCorrectPos<T>(this Matrix<T> matrix, Vector2Int pos)
        {
            return matrix.IsCorrectPos(pos.Y, pos.X);
        }
    }
}