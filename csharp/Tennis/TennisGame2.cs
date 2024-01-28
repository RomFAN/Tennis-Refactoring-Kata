namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1Point;
        private int p2Point;
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1Point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (p1Point == p2Point)
            {
                return GetTieResult();
            }

            if (p1Point >= 4 || p2Point >= 4)
            {
                return GetEndGameResult();
            }

            return GetMidGameResult();
        }

        private string GetTieResult()
        {
            return p1Point switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }

        private string GetMidGameResult()
        {
            return $"{ConvertPointsToString(p1Point)}-{ConvertPointsToString(p2Point)}";
        }

        private string GetEndGameResult()
        {
            int negativeResult = p1Point - p2Point;

            if (negativeResult == 1) return "Advantage player1";
            if (negativeResult == -1) return "Advantage player2";
            if (negativeResult >= 2) return "Win for player1";
            return "Win for player2";
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                p1Point++;
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                p2Point++;
            }
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                p1Point++;
            else
                p2Point++;
        }

        private string ConvertPointsToString(int points)
        {
            return points switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "",
            };
        }

    }
}

