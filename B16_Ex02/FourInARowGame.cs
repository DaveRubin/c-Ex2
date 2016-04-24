﻿using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    class FourInARowGame
    {
        public const int k_MinDimension = 4;
        public const int k_MaxDimension = 8;

        private Board m_board;
        private List<Player> m_players;
        private int m_currentPlayerIndex;
        private eGameMode m_gameMode;


        public FourInARowGame()
        {
            InitializeBoard();
            InitializeGameMode();
            StartGame();
        }

        /// <summary>
        /// Get Board dimensions from user and initialize it
        /// </summary>
        private void InitializeBoard()
        {
            int columns;
            int rows;

            GameView.GetBoardDimensions(out columns,out rows);

            //initialize board
            m_board = new Board(columns,rows);
        }

        /// <summary>
        /// Get the game mode from user and initialize players
        /// </summary>
        private void InitializeGameMode()
        {
            bool playerHumanity = true;
            m_players = new List<Player>();
            m_players.Add(new Player(GameTexts.k_Player1Name, playerHumanity));
            m_gameMode = GameView.GetGameMode();

            if (m_gameMode == eGameMode.TwoPlayers)
            {
                m_players.Add(new Player(GameTexts.k_Player2Name, playerHumanity));
            }
            else
            {
                playerHumanity = false;
                m_players.Add(new Player(GameTexts.k_ComputerName, playerHumanity));
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
            GameView.ShowTurnScreen(m_board, m_players[m_currentPlayerIndex].r_name);
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
            GameView.ShowTieScreen();
            ShowRestartScreen();
        }

        private void PlayAgain()
        {
            m_board.EmptyBoard();
            m_currentPlayerIndex = 0;
            TakeTurn();
        }

        /// <summary>
        /// Congradulate winner
        /// </summary>
        private void ShowGameWinScreen()
        {
            Player winner = m_players[m_currentPlayerIndex];
            winner.Score++;
            GameView.ShowWinScreen(winner);
            ShowRestartScreen();
        }

        /// <summary>
        /// Show PlayAgain screen and wait for user input
        /// exit game or continue to another accordingly
        /// </summary>
        private void ShowRestartScreen()
        {
            bool restartGameUserSelection = GameView.RestartGameMessage(m_players);
            if (restartGameUserSelection)
            {
                PlayAgain();
            }
            else
            {
                ExitGame();
            }
        }

        /// <summary>
        /// When exiting game show good bye screeen
        /// </summary>
        private void ExitGame()
        {
            GameView.ShowGoodByeScreen();
        }

        /// <summary>
        /// Check board for winner
        /// </summary>
        /// <returns></returns>
        private bool CheckIfWin()
        {
            return BoardAnalyzer.IsGameWon(ref m_board);
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
                Console.WriteLine(string.Format(GameTexts.k_ColumnIsntFreeMessageTemplate, selectedColumn));
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
