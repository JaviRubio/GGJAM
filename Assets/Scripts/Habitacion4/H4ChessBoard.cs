using System.Collections;

namespace Habitacion4
{
    enum Name
    {
        King, Queen, Knight, Bishop, Pawn
    }

    enum Color
    {
        Black,White
    }

    class Piece
    {
        public readonly Name Name;
        public readonly Color Color;
        public int X;
        public int Y;
        
        public Piece(Name name, int x, int y, Color color)
        {
            Name = name;
            X = x;
            Y = y;
            Color = color;
        }
    }

    class H4ChessBoard
    {

        private readonly ArrayList _pieces;

        public H4ChessBoard()
        {
            _pieces = new ArrayList
            {
                new Piece(Name.Knight, 2, 4,Color.White),
                new Piece(Name.Knight, 4, 4,Color.White),
                new Piece(Name.Bishop, 3, 5,Color.White),
                new Piece(Name.King, 6, 7,Color.White),
                new Piece(Name.King, 3, 7, Color.Black), new Piece(Name.Pawn, 3, 6, Color.Black)
            };
        }

        public ArrayList GetPieces()
        {
            return _pieces;
        }
        public bool GenerateFirstBlackMovement()
        {
            if (IsThereAPiece(7, 6))
            {
                var king = PeekPiece(3, 7);
                king.X++;
                return true;
            }
            return false;
        }
        public bool GenerateSecondBlackMovement()
        {
            if (IsThereAPiece(4, 5))
            {
                RemovePiece(3, 6);
                PutPiece(new Piece(Name.Queen, 3,7,Color.Black));
                return true;
            }
            return false;
        }

        public bool CheckIsSolved()
        {
            return PeekPiece(6, 5).Name == Name.Knight &&
                   PeekPiece(4, 4).Name == Name.Knight &&
                   PeekPiece(3, 5).Name == Name.Bishop &&
                   PeekPiece(7, 6).Name == Name.King &&
                   PeekPiece(4, 7).Name == Name.King &&
                   PeekPiece(3, 7).Name == Name.Queen;
        }

        public bool IsThereAPiece(int x, int y)
        {
            foreach (Piece p in _pieces)
            {
                if (p.X == x && p.Y == y)
                {
                    return true;
                }
            }
            return false;
        }
        public void PutPiece(Piece p)
        {
            _pieces.Add(p);
        }

        /*
         * Get the piece from the board, the place of the piece will be empty after this call.
         */
        public Piece RemovePiece(int x, int y)
        {
            var result = PeekPiece(x, y);
            if (result != null)
            {
                _pieces.Remove(result);
            }
            return result;
        }

        /*
         * Get the piece reference without remove it.
         */
        public Piece PeekPiece(int x, int y)
        {
            foreach (Piece p in _pieces)
            {
                if (p.X == x && p.Y == y)
                {
                    return p;
                }
            }
            return null;
        }

    }
}
