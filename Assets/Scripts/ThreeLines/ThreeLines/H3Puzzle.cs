namespace ThreeLines
{
    class H3Puzzle
    {
        private readonly char[] _ground;
        private int _count;
        private readonly int _width;
        private readonly int _height;
        private const string Secret = "LOSSECRETOSNOSHACENVIVIRENLASSOMBRAS";

        public H3Puzzle()
        {
            _width = 14;
            _height = 6;
            _count = 0;
            _ground = new[]
            {
                'B','L','A','V','E','N','V','I','R','U','A','S','S','O',
                'A','O','S','I','C','O','M','V','I','S','L','O','O','L',
                'R','S','S','S','A','H','E','R','R','E','N','L','M','A',
                'I','R','E','T','O','S','D','I','C','L','C','I','B','J',
                'T','R','C','A','N','A','D','I','P','O','I','A','R','D',
                'S','E','T','O','S','V','A','L','E','N','T','S','S','P'
            };
            Reset();
        }

        public bool CheckIsSolved()
        {
            return _count == Secret.Length;
        }
        public bool WalkTile(int x, int y)
        {
            int d = y * _width + x;
            if (d < 0 || d >= _width * _height) return false;
            if (_ground[d] == Secret[_count])
            {
                ++_count;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}
