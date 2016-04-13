using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    class FourInARowGame
    {
        private Board m_board;
        private Player[] m_players;
        private int m_currentPlayerIndex;
        private eGameMode m_gameMode;

        private const string DimensionsInputTemplate = "Please enter number of {0} between {1} and {2}";

        public FourInARowGame()
        {
            InitializeBoard();
            InitializeGameMode();
            StartGame();
//            Board b = new Board(5,4);
//            Console.ReadLine();
//            b.AddPieceToColumn(2, Board.eSlotState.Player1);
//            b.AddPieceToColumn(2, Board.eSlotState.Player2);
//            b.AddPieceToColumn(2, Board.eSlotState.Player1);
//            b.AddPieceToColumn(2, Board.eSlotState.Player1);
//            b.AddPieceToColumn(2, Board.eSlotState.Player1);
//            b.UpdateBoard();
//            Console.ReadLine();
//            b.AddPieceToColumn(0, Board.eSlotState.Player1);
//            b.AddPieceToColumn(1, Board.eSlotState.Player2);
//            b.AddPieceToColumn(3, Board.eSlotState.Player1);
//            b.AddPieceToColumn(0, Board.eSlotState.Player2);
//            b.UpdateBoard();
        }

        private void InitializeBoard()
        {

            //get columns
            Console.WriteLine(string.Format(DimensionsInputTemplate,"columns",4,8));
            int columns = NumberUtils.GetBoundedIntFromConsole(4, 8);
            //get rows
            Console.WriteLine(string.Format(DimensionsInputTemplate, "rows", 4, 8));
            int rows = NumberUtils.GetBoundedIntFromConsole(4, 8);
            //initialize board
            m_board = new Board(columns,rows);

        }

        private void InitializeGameMode()
        {

        }

        private void StartGame()
        {
            m_board.PrintBoard();
        }

        public enum eGameMode
        {
            TwoPlayers,
            ManVsMachine
        }

    }
}
