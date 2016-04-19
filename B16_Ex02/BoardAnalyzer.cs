using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class BoardAnalyzer
    {
        internal static bool IsGameWon(ref Board i_Board)
        {

            /// Vertical search for winner
            for (int row = 0; row < i_Board.r_numOfRows - 3; row++)
            {
                for (int col = 0; col < i_Board.r_numOfColumns; col++)
                {
                    if (i_Board.m_slotsMatrix[row, col] != Board.eSlotState.Empty &&
                    i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row + 1, col] &&
                    i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row + 2, col] &&
                    i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row + 3, col])
                    {
                        return true;
                    }
                }
            }

            /// Horizontal search for winner
            for (int row = 0; row < i_Board.r_numOfRows; row++)
            {
                for (int col = 0; col < i_Board.r_numOfColumns - 3; col++)
                {
                    if (i_Board.m_slotsMatrix[row, col] != Board.eSlotState.Empty &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row, col + 1] &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row, col + 2] &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row, col + 3])
                    {
                        return true;
                    }
                } 
            }

            /// Right and down diagonal search for winner
            for (int row = 0; row < i_Board.r_numOfRows - 3; row++)
            {
                for (int col = 0; col < i_Board.r_numOfColumns - 3; col++)
                {
                    if (i_Board.m_slotsMatrix[row, col] != Board.eSlotState.Empty &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row + 1, col + 1] &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row + 2, col + 2] &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row + 3, col + 3])
                    {
                        return true;
                    }
                }
            }

            /// Right and up diagonal search for winner
            for (int row = 3; row < i_Board.r_numOfRows; row++)
            {
                for (int col = 0; col < i_Board.r_numOfColumns - 3; col++)
                {
                    if (i_Board.m_slotsMatrix[row, col] != Board.eSlotState.Empty &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row - 1, col + 1] &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row - 2, col + 2] &&
                        i_Board.m_slotsMatrix[row, col] == i_Board.m_slotsMatrix[row - 3, col + 3])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        

        internal static bool IsWinnningMove(ref Board i_Board, int i_col, Board.eSlotState i_pieceType)
        {
            if (i_Board.AddPieceToColumn(i_col,i_pieceType))
            {
                return IsGameWon(ref i_Board);
            }
            else
            {
                return false;
            }
        }


    }
}
