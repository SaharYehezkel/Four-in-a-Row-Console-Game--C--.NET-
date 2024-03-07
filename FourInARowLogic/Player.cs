namespace FourInARowGameLogic
{
    public class Player
    {
        private int m_Wins;
        private int m_Draws;
        private int m_Loses;

        public Player()
        {
            m_Wins = 0;
            m_Draws = 0;
            m_Loses = 0;
        }

        public int Wins
        {
            get
            {
                return m_Wins;
            }
            set
            {
                m_Wins++;
            }
        }

        public int Draws
        {
            get
            {
                return m_Draws;
            }
            set
            {
                m_Draws++;
            }
        }

        public int Loses
        {
            get
            {
                return m_Loses;
            }
            set
            {
                m_Loses++;
            }
        }
    }
}
