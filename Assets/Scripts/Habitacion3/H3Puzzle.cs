using System;
using System.Collections.Generic;
//using System.Data;
using System.Text;

namespace Habitacion3
{
    class H3Puzzle
    {
        private readonly char[] _ground;
        private Stack<char> _chars;
        private readonly int _width;
        private readonly int _height;

        public H3Puzzle()
        {
            _width = 14;
            _height = 6;
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
            return _chars.Count == 0;
        }
        public bool WalkTile(int x, int y)
        {
            int d = y * _width + x;
            if (d < 0 || d >= _width * _height) return false;
            if (_ground[d] == _chars.Peek())
            {
                _chars.Pop();
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            _chars = new Stack<char>();
            _chars = new Stack<char>();
            _chars.Push('S');
            _chars.Push('A');
            _chars.Push('R');
            _chars.Push('B');
            _chars.Push('M');
            _chars.Push('O');
            _chars.Push('S');
            _chars.Push('S');
            _chars.Push('A');
            _chars.Push('L');
            _chars.Push('N');
            _chars.Push('E');
            _chars.Push('R');
            _chars.Push('I');
            _chars.Push('V');
            _chars.Push('I');
            _chars.Push('V');
            _chars.Push('N');
            _chars.Push('E');
            _chars.Push('C');
            _chars.Push('A');
            _chars.Push('H');
            _chars.Push('S');
            _chars.Push('O');
            _chars.Push('N');
            _chars.Push('S');
            _chars.Push('O');
            _chars.Push('T');
            _chars.Push('E');
            _chars.Push('R');
            _chars.Push('C');
            _chars.Push('E');
            _chars.Push('S');
            _chars.Push('S');
            _chars.Push('O');
            _chars.Push('L');
        }
    }
}
