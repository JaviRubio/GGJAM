using System.Collections.Generic;

namespace ThreeLines
{
    class H6Piano
    {
        private readonly int[] _pastSolution;
        private readonly int[] _presentSolution;
        private readonly int[] _futureSolution;
        private int _count;

        public H6Piano()
        {
            _pastSolution = new[]
            {
                14, 17, 21, 19, 21, 17, 16, 14
            };
            _presentSolution = new[]
            {
                14, 17, 21, 24, 26, 23, 19, 14
            };
            _futureSolution = new[]
            {
                14, 17, 21, 19, 16, 12, 5, 7, 9
            };
            _count = 0;
        }

        public bool CheckPastSolved()
        {
            return _count == _pastSolution.Length;
        }
        public bool CheckPresentSolved()
        {
            return _count == _presentSolution.Length;
        }
        public bool CheckFutureSolved()
        {
            return _count == _futureSolution.Length;
        }
        public bool CheckPastNote(int note)
        {
            return CheckNote(_pastSolution, note);
        }
        public bool CheckPresentNote(int note)
        {
            return CheckNote(_presentSolution, note);
        }
        public bool CheckFutureNote(int note)
        {
            return CheckNote(_futureSolution, note);
        }

        private bool CheckNote(IList<int> solution, int note)
        {
            if (solution[_count] == note)
            {
                ++_count;
                return true;
            }
            _count = 0;
            return false;
        }
    }
}
