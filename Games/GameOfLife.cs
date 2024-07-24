namespace Finale.Games {
    public class GameOfLife {
        private bool[][] board;

        public bool[][] Board {
            get {
                bool[][] res = new bool[Height][];
                for (uint i = 0; i < Height; i++) {
                    res[i] = new bool[Width];
                    for (uint j = 0; j < Width; j++) {
                        res[i][j] = this.board[i][j];
                    }
                }
                return res;
            }
            set {
                if (value.Length != Height || value[0].Length != Width)
                    throw new System.Exception("Invalid dimensions");
                for (uint i = 0; i < Height; i++) {
                    for (uint j = 0; j < Width; j++) {
                        this.board[i][j] = value[i][j];
                    }
                }
            }
        }

        public uint Width {
            get {
                return (uint)this.board[0].Length;
            }
            set {
                if (value == Width)
                    return;
                if (value < Width)
                    ReduceWidth(value);
                else
                    ExtendWidth(value);
            }
        }

        public uint Height {
            get {
                return (uint)this.board.Length;
            }
            set {
                if (value == Height)
                    return;
                if (value < Height)
                    ReduceHeight(value);
                else
                    ExtendHeight(value);
            }
        }

        public GameOfLife(uint rows, uint cols) {
            this.board = new bool[rows][];
            for (uint row = 0; row < rows; row++) {
                this.board[row] = new bool[cols];
            }
        }

        public GameOfLife(bool[][] board) {
            board = new bool[board.Length][];
            for (uint row = 0; row < board.Length; row++) {
                board[row] = new bool[board[row].Length];
                for (uint col = 0; col < board[row].Length; col++) {
                    board[row][col] = board[row][col];
                }
            }
        }

        public void SetCell(uint row, uint col, bool value) {
            this.board[row][col] = value;
        }

        public void Next() {
            bool[][] new_board = new bool[Height][];
            int neighbors;
            for (uint row = 0; row < Height; row++) {
                new_board[row] = new bool[Width];
                for (uint col = 0; col < Width; col++) {
                    neighbors = CountNeighbors(row, col);
                    new_board[row][col] = NextGenState(this.board[row][col], neighbors);
                }
            }
            this.board = new_board;
        }
        private void ReduceWidth(uint new_width) {
            bool[][] mat = new bool[Height][];
            for (uint row = 0; row < Height; row++) {
                mat[row] = new bool[new_width];
                for (uint col = 0; col < new_width; col++) {
                    mat[row][col] = this.board[row][col];
                }
            }
        }
        private void ExtendWidth(uint new_width) {
            bool[][] mat = new bool[Height][];
            uint col;
            for (uint row = 0; row < Height; row++) {
                mat[row] = new bool[new_width];
                for (col = 0; col < Width; col++) {
                    mat[row][col] = this.board[row][col];
                }
                for (; col < new_width; col++) {
                    mat[row][col] = false;
                }
            }
            this.board = mat;
        }
        private void ReduceHeight(uint new_height) {
            bool[][] mat = new bool[new_height][];
            for (uint row = 0; row < new_height; row++) {
                mat[row] = this.board[row];
            }
            this.board = mat;
        }
        private void ExtendHeight(uint new_height) {
            bool[][] mat = new bool[new_height][];
            uint row;
            for (row = 0; row < Height; row++) {
                mat[row] = this.board[row];
            }
            for (; row < new_height; row++) {
                mat[row] = new bool[Width];
            }
            this.board = mat;
        }
        private int CountNeighbors(uint row, uint col) {
            int count = 0;
            for (int _row = -1; _row <= 1; _row++) {
                for (int _col = -1; _col <= 1; _col++) {
                    if (_row == 0 && _col == 0)
                        continue;
                    if (row + _row < 0 || row + _row >= Height || col + _col < 0 || col + _col >= Width)
                        continue;
                    if (this.board[row + _row][col + _col])
                        count++;
                }
            }
            return count;
        }
        /*
         if cell live:
            if neighbors < 2: underpopulation, die
                die
            if neighbors == 2 or 3: survive
                live
            if neighbors > 3: overpopulation, 
                die
        if cell dead:
            if neighbors == 3: reproduction
                    live
            else:
                die
         */
        private bool NextGenState(bool state, int neighbors) {
            if (state) {
                return neighbors == 2 || neighbors == 3;
            }
            return neighbors == 3;
        }
    }
}
