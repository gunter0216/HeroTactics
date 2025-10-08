namespace App.Menu.UI.External
{
    public class BattleFieldCell
    {
        private readonly int m_X;
        private readonly int m_Y;

        public int X => m_X;
        public int Y => m_Y;

        public BattleFieldCell(int x, int y)
        {
            m_X = x;
            m_Y = y;
        }
    }
}