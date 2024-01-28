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
            var score = "";
            if (p1Point == p2Point && p1Point < 3)
            {
                score =  $"{ConvertPointsToString(p1Point)}-All"; 
            }
            if (p1Point == p2Point && p1Point > 2)
                score = "Deuce";

            if (p1Point > 0 && p2Point == 0)
            {
                score = $"{ConvertPointsToString(p1Point)}-Love";  
            }
            if (p2Point > 0 && p1Point == 0)
            {
                score = $"Love-{ConvertPointsToString(p2Point)}";  
            }

            if (p1Point > p2Point && p1Point < 4)
            {
                score = $"{ConvertPointsToString(p1Point)}-{ConvertPointsToString(p2Point)}";
            }
            if (p2Point > p1Point && p2Point < 4)
            {        
                score = $"{ConvertPointsToString(p1Point)}-{ConvertPointsToString(p2Point)}";
            }

            if (p1Point > p2Point && p2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2Point > p1Point && p1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1Point >= 4 && p2Point >= 0 && (p1Point - p2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2Point >= 4 && p1Point >= 0 && (p2Point - p1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1Point++;
        }

        private void P2Score()
        {
            p2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
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

