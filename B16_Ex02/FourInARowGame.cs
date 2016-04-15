using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    class FourInARowGame
    {
        public const int k_MinDimension = 4;
        public const int k_MaxDimension = 8;
        public const string k_ColumnIsntFreeMessageTemplate = "Column {0} isn't free, please choose another";

        private const string k_Player1Name = "Player1";
        private const string k_Player2Name = "Player2";

        private Board m_board;
        private List<Player> m_players;
        private int m_currentPlayerIndex;
        private eGameMode m_gameMode;


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

        /// <summary>
        /// Get Board dimensions from user and initialize it
        /// </summary>
        private void InitializeBoard()
        {
            int columns;
            int rows;

            Menus.GetBoardDimensions(out columns,out rows);

            //initialize board
            m_board = new Board(columns,rows);
        }

        /// <summary>
        /// Get the game mode from user and initialize players
        /// </summary>
        private void InitializeGameMode()
        {
            m_players = new List<Player>();
            m_players.Add(new HumanPlayer(k_Player1Name));
            m_gameMode = Menus.GetGameMode();

            if (m_gameMode == eGameMode.TwoPlayers)
            {
                m_players.Add(new ComputerPlayer());
            }
            else
            {
                m_players.Add(new HumanPlayer(k_Player2Name));
            }
        }

        /// <summary>
        /// Start the game for the first time
        /// </summary>
        private void StartGame()
        {
            TakeTurn();
        }

        /// <summary>
        /// Game turn sequence
        /// </summary>
        private void TakeTurn()
        {
            m_board.PrintBoard();
            PlayerMove();
            if (CheckIfWin())
            {
                ShowGameWinScreen();
            }
            else
            {
                if (m_board.IsFull)
                {
                    ShowGameTieScreen();
                }
                else
                {
                    m_currentPlayerIndex = (m_currentPlayerIndex + 1) % 2;
                    TakeTurn();
                }
            }
        }

        private void ShowGameTieScreen()
        {
            Menus.ShowTieScreen();
            if (Menus.RestartGameMessage())
            {
                Restart();
            }
            else
            {
                Menus.GoodByeScreen();
            }
        }

        private void Restart()
        {
            
        }

        private void ShowGameWinScreen()
        {
            Menus.ShowWinScreen(m_players[m_currentPlayerIndex].r_name);
        }

        private bool CheckIfWin()
        {
            return false;
        }

        /// <summary>
        /// The player should select a column
        /// </summary>
        private void PlayerMove()
        {
            //int selectedColumn = m_players[m_currentPlayerIndex].SelectColumn();
            int selectedColumn = InputUtils.GetIntFromConsole();
            Board.eSlotState playerPieceType = (m_currentPlayerIndex == 0)
                                                   ? Board.eSlotState.Player1
                                                   : Board.eSlotState.Player2;
            while (!m_board.AddPieceToColumn(selectedColumn,playerPieceType))
            {
                Console.WriteLine(string.Format(k_ColumnIsntFreeMessageTemplate, selectedColumn));
                selectedColumn = m_players[m_currentPlayerIndex].SelectColumn();
                selectedColumn = InputUtils.GetIntFromConsole();
            }
        }

        public enum eGameMode
        {
            TwoPlayers,
            ManVsMachine
        }

    }
}
