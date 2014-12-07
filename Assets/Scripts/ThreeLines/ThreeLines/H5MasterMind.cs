using System.Collections.Generic;

namespace ThreeLines
{
    enum ColorBall
    {
        Red,Green, Blue, Yellow, Black, White
    }

    class H5MasterMind
    {
        private readonly ColorBall[] _pastRows;
        private readonly ColorBall[] _presentRows;
        private readonly ColorBall[] _futureRows;
        private readonly ColorBall[] _playerRows;

        public H5MasterMind()
        {
            _pastRows = new[]
            {
                ColorBall.Red, ColorBall.Red, ColorBall.Green, ColorBall.Blue,
                ColorBall.Blue, ColorBall.Blue, ColorBall.Yellow, ColorBall.Yellow
            };
            _presentRows = new[]
            {
                ColorBall.Red, ColorBall.Yellow, ColorBall.Yellow, ColorBall.Red,
                ColorBall.Green, ColorBall.White, ColorBall.Green, ColorBall.Blue
            };
            _futureRows = new[]
            {
                ColorBall.Green, ColorBall.Green, ColorBall.Red, ColorBall.Red,
                ColorBall.Blue, ColorBall.Black, ColorBall.Blue, ColorBall.Yellow
            };
            _playerRows = new ColorBall[8];
        }

        /*
         * cellNumber[0..3]
         */
        public void SetPlayerRow1Cell(int cellNumber, ColorBall ball)
        {
            _playerRows[cellNumber] = ball;
        }

        /*
         * cellNumber[0..3]
         */
        public ColorBall GetPlayerRow1Cell(int cellNumber)
        {
            return _playerRows[cellNumber];
        }

        /*
         * cellNumber[0..3]
         */
        public ColorBall GetPlayerRow2Cell(int cellNumber)
        {
            return _playerRows[cellNumber+4];
        }
        /*
         * cellNumber[0..3]
         */
        public void SetPlayerRow2Cell(int cellNumber, ColorBall ball)
        {
            _playerRows[cellNumber+4] = ball;
        }

        /*
         * Get the default past box balls.
         */
        public IList<ColorBall> GetPastBoxBalls()
        {
            return new[]
            {
                ColorBall.Red, ColorBall.Red, ColorBall.Red, ColorBall.Red,
                ColorBall.Green, ColorBall.Green, ColorBall.Green, ColorBall.Green,
                ColorBall.Blue, ColorBall.Blue, ColorBall.Blue, ColorBall.Blue,
                ColorBall.Yellow, ColorBall.Yellow, ColorBall.Yellow, ColorBall.Yellow
            };
        }

        /*
         * Get the box balls based in right balls count.
         */
        public IList<ColorBall> GetPresentBoxBalls(int count)
        {
            IList<ColorBall> balls = new[]
                {
                    ColorBall.Red, ColorBall.Red,
                    ColorBall.Green, ColorBall.Green,
                    ColorBall.Blue, ColorBall.Blue,
                    ColorBall.Yellow, ColorBall.Yellow,
                    ColorBall.White
                };
            return GetBoxBalls(balls, count);
        }

        /*
         * Get the box balls based in right balls count.
         */
        public IList<ColorBall> GetFutureBoxBalls(int count)
        {
            IList<ColorBall> balls = new[]
                {
                    ColorBall.Red, ColorBall.Red,
                    ColorBall.Green, ColorBall.Green,
                    ColorBall.Blue, ColorBall.Blue,
                    ColorBall.Yellow, ColorBall.Yellow,
                    ColorBall.Black
                };
            return GetBoxBalls(balls, count);
        }

        private IList<ColorBall> GetBoxBalls(IList<ColorBall> rightBalls, int count)
        {
            if (count == _pastRows.Length)
            {
                return rightBalls;
            }
            IList<ColorBall> result = new ColorBall[count];
            for (var i = 0; i < count; ++i)
            {
                result[i] = rightBalls[i];
            }
            return result;
        }

        /*
         * Get the right balls count.
         */
        public int CountPastSolvedBalls(IList<ColorBall> playerRow)
        {
            return CountSolvedBalls(playerRow, _pastRows);
        }
        /*
         * Get the right balls count.
         */
        public int CountPresentSolvedBalls(IList<ColorBall> playerRow)
        {
            return CountSolvedBalls(playerRow, _presentRows);
        }
        /*
         * Get the right balls count.
         */
        public int CountFutureSolvedBalls(IList<ColorBall> playerRow)
        {
            return CountSolvedBalls(playerRow, _futureRows);
        }

        private int CountSolvedBalls(IList<ColorBall> actual, IList<ColorBall> rightrow)
        {
            var count = 0;
            for(var i=0; i<rightrow.Count; ++i)
            {
                if (actual[i] == rightrow[i]) ++count;
            }
            return count;
        }
    }
}
