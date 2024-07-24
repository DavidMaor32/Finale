using System;
using System.Drawing;
using System.Linq;

namespace Finale.TicTieToe {
    public class TicTieToe {
        public static readonly int BOARD_SIZE = 3;

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
            if (this.board[row][col] != State.Empty)
                throw new Exception("Invalid move");
            this.board[row][col] = State.X;
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
            if (player == State.Empty)
                return new Point(-1, -1);
            int row,col;
            int count_player = 0, count_empty = 0;
            return new Point(-1, -1);
        }
        private void MoveComputer() { }



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
    }
}
