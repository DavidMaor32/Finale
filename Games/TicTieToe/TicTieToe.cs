using System;
using System.Linq;

namespace Finale.TicTieToe {
    public class TicTieToe {
        public static readonly int BOARD_SIZE = 3;

        public Point LastMove { get; private set; }
        public State LastPlayedBy { get; private set; }

        private State[][] board;

        public TicTieToe() {
            this.board = new State[BOARD_SIZE][];
            for (int row = 0; row < BOARD_SIZE; row++) {
                this.board[row] = new State[BOARD_SIZE];
                for (int col = 0; col < BOARD_SIZE; col++)
                    this.board[row][col] = State.Empty;
            }
        }

        public State[][] GetBoard() {
            State[][] stateTicTieToes = new State[BOARD_SIZE][];
            for (int row = 0; row < BOARD_SIZE; row++) {
                stateTicTieToes[row] = new State[BOARD_SIZE];
                for (int col = 0; col < BOARD_SIZE; col++)
                    stateTicTieToes[row][col] = this.board[row][col];
            }
            return stateTicTieToes;
        }

        public void MakeMove(int row, int col) {
            MakeMove(State.X, row, col);
            MoveComputer();
        }

        public State GetWinner() {
            if (IsWin(this.board, State.X))
                return State.X;
            if (IsWin(this.board, State.O))
                return State.O;
            return State.Empty;
        }

        private void MakeMove(State player, int row, int col) {
            if (row < 0 || row >= BOARD_SIZE || col < 0 || col >= BOARD_SIZE)
                return;
            if (this.board[row][col] != State.Empty)
                throw new Exception("Invalid move");
            this.board[row][col] = player;
            LastMove = new Point(row, col);
            LastPlayedBy = player;
        }

        public bool IsBoardFull() {
            for (int i = 0; i < BOARD_SIZE; i++) {
                for (int j = 0; j < BOARD_SIZE; j++) {
                    if (this.board[i][j] == State.Empty)
                        return false;
                }
            }
            return true;
        }

        private Point GetWinMove(State player) {
            Point GetWinRows(State p) {
                int row, col;
                int empty_col = -1;
                bool flag = true;
                for (row = 0; row < BOARD_SIZE; row++) {
                    empty_col = -1;
                    flag = true;
                    for (col = 0; col < BOARD_SIZE; col++) {
                        if (this.board[row][col] == State.Empty) {
                            if (empty_col != -1) {
                                flag = false;
                                break;
                            }
                            empty_col = col;
                        }
                        else if (this.board[row][col] != p)
                            break;
                    }
                    if (flag && empty_col != -1) {
                        return new Point(row, empty_col);
                    }
                }
                return new Point(-1, -1);
            }
            Point GetWinCols(State p) {
                int col, row;
                int empty_row = -1;
                bool flag = true;
                for (col = 0; col < BOARD_SIZE; col++) {
                    flag = true;
                    empty_row = -1;
                    for (row = 0; row < BOARD_SIZE; row++) {
                        if (this.board[row][col] == State.Empty) {
                            if (empty_row != -1) {
                                flag = false;
                                break;
                            }
                            empty_row = row;
                        }
                        else if (this.board[row][col] != p)
                            break;
                    }
                    if (flag && empty_row != -1) {
                        return new Point(empty_row, col);
                    }
                }
                return new Point(-1, -1);
            }
            Point GetWinDiagonal(State p) {
                int found_empty = -1;
                for (int i = 0; i < BOARD_SIZE; i++) {
                    if (this.board[i][i] == State.Empty) {
                        if (found_empty != -1)
                            return new Point(-1, -1);
                        found_empty = i;
                    }
                    else if (this.board[i][i] != p)
                        return new Point(-1, -1);
                }
                return new Point(found_empty, found_empty);
            }
            Point GetWinAntiDiagonal(State p) {
                int found_empty = -1;
                for (int i = 0; i < BOARD_SIZE; i++) {
                    if (this.board[i][BOARD_SIZE - 1 - i] == State.Empty) {
                        if (found_empty != -1)
                            return new Point(-1, -1);
                        found_empty = i;
                    }
                    else if (this.board[i][BOARD_SIZE - 1 - i] != p)
                        return new Point(-1, -1);
                }
                return new Point(found_empty, BOARD_SIZE - 1 - found_empty);
            }

            Point notfound = new Point(-1, -1);
            if (IsBoardFull())
                return notfound;

            Point point;
            if ((point = GetWinRows(player)) != notfound)
                return point;
            if ((point = GetWinCols(player)) != notfound)
                return point;
            if ((point = GetWinDiagonal(player)) != notfound)
                return point;
            else
                return GetWinAntiDiagonal(player);
        }
        private void MoveComputer() {
            if (IsBoardFull())
                return;
            if (IsWin(this.board, State.X))
                return;
            Point move;
            move = GetWinMove(State.O);
            if (move.Equals(new Point(-1, -1)))
                move = GetWinMove(State.X);
            else if (move.Equals(new Point(-1, -1))) {
                Random r = new Random();
                do {
                    move = new Point(r.Next(0, BOARD_SIZE), r.Next(0, BOARD_SIZE));
                } while (this.board[move.X][move.Y] != State.Empty);
            }
            MakeMove(State.O, move.X, move.Y);
        }



        private bool IsWin(State[][] board, State player) {
            if (board.Any(row => row.All(cell => cell == player)))
                return true;
            for (int i = 0; i < BOARD_SIZE; i++) {
                if (board.All(row => row[i] == player))
                    return true;
            }
            for (int i = 0; i < BOARD_SIZE; i++) {
                if (board[i][i] != player)
                    break;
                if (i == BOARD_SIZE - 1)
                    return true;
            }
            for (int i = 0; i < BOARD_SIZE; i++) {
                if (board[i][BOARD_SIZE - 1 - i] != player)
                    break;
                if (i == BOARD_SIZE - 1)
                    return true;
            }
            return false;
        }

        public class Point {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y) {
                X = x;
                Y = y;
            }

            public bool Equals(Point p) {
                return X == p.X && Y == p.Y;
            }
        }
    }
}
