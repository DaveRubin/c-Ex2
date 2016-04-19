using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class Board
    {
        public readonly int r_numOfRows;
        public readonly int r_numOfColumns;
        public eSlotState[,] m_slotsMatrix;

        private const char k_P1Symbol = 'O';
        private const char k_P2Symbol = 'X';
        private const char k_EmptySymbol = ' ';
        private const string k_SlotTemplate = @"  {0}  ";
        private const char k_TableHorizontalSeperatorChar = '|';
        private const char k_TableVerticalSeperatorChar = '=';

        public eSlotState[,] SlotsMatrix
        {
            get
            {
                //TODO: ask about a more efficient way to get the matrix out and still protect 'slotsMatrix' data
                return (eSlotState[,])m_slotsMatrix.Clone();
            }
        }

        public bool IsFull
        {
            get
            {
                bool result = true;
                for (int i = 0; i < r_numOfColumns; i++)
                {
                    if (IsColumnFree(i))
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// on construction, create the new matrix and initialize memebers
        /// </summary>
        /// <param name="i_columns"></param>
        /// <param name="i_rows"></param>
        public Board(int i_columns, int i_rows )
        {
            r_numOfRows = i_rows;
            r_numOfColumns = i_columns;
            m_slotsMatrix = new eSlotState[i_columns, i_rows];
            EmptyBoard();
        }



        /// <summary>
        /// Clear screen and Prints the board 
        /// </summary>
        public void PrintBoard()
        {
            StringBuilder separatorRow = new StringBuilder();
            int seperatorRowLength = r_numOfColumns * (k_SlotTemplate.Length - 1) + 1;
            separatorRow.Append(k_TableVerticalSeperatorChar, seperatorRowLength);

            Ex02.ConsoleUtils.Screen.Clear();
            PrintHeaderRow();
            for (int row = 0; row < r_numOfRows; row++)
            {
                for (int column = 0; column < r_numOfColumns; column++)
                {
                    eSlotState slotType = m_slotsMatrix[column, row];

                    if (column == 0)
                    {
                        Console.Write(k_TableHorizontalSeperatorChar);
                    }

                    Printslot(slotType);
                    Console.Write(k_TableHorizontalSeperatorChar);

                }

                Console.Write(Environment.NewLine);
                Console.WriteLine(separatorRow);
            }

            //extra padding at the bottom
            Console.Write(Environment.NewLine);
        }

        /// <summary>
        /// Print the board header with number for each column
        /// </summary>
        private void PrintHeaderRow()
        {
            Console.Write(' ');
            for (int column = 0; column < r_numOfColumns; column++)
            {
                Console.Write(string.Format(k_SlotTemplate, column + 1));
                Console.Write(' ');
            }
            Console.Write(Environment.NewLine);
        }

        /// <summary>
        /// Print board slot from string template
        /// </summary>
        /// <param name="i_slotType"></param>
        private void Printslot(eSlotState i_slotType)
        {
            char slotPieceView = k_EmptySymbol;
            switch (i_slotType)
            {
                case  eSlotState.Empty:
                    slotPieceView = k_EmptySymbol;
                    break;
                    
                case  eSlotState.Player1:
                    slotPieceView = k_P1Symbol;
                    break;
                
                case eSlotState.Player2:
                    slotPieceView = k_P2Symbol;
                    break;
            }

            Console.Write(string.Format(k_SlotTemplate,slotPieceView));
        }

        //add piece to column , 
        //return false if column is full
        public bool AddPieceToColumn(int i_column, eSlotState i_pieceType)
        {
            bool success = true;

            if (IsColumnFree(i_column))
            {
                int targetRow = r_numOfRows - 1;

                while (m_slotsMatrix[i_column, targetRow] != eSlotState.Empty)
                {
                    targetRow--;
                }

                m_slotsMatrix[i_column, targetRow] = i_pieceType;
            }
            else
            {
                success = false;
            }

            return success;
        }
        //remove piece from column
        public void RemovePieceFromColumn(int i_column)
        {
            int targetRow = r_numOfRows - 1;
            if (m_slotsMatrix[i_column, targetRow] != eSlotState.Empty)
            {
                while (m_slotsMatrix[i_column, targetRow] != eSlotState.Empty)
                {
                    targetRow--;
                }
                m_slotsMatrix[i_column, targetRow + 1] = eSlotState.Empty;
            }
        }

        /// <summary>
        /// Set all slots to be "Empty"
        /// </summary>
        public void EmptyBoard()
        {
            for (int i = 0; i < r_numOfColumns; i++)
            {
                for (int j = 0; j < r_numOfRows; j++)
                {
                    m_slotsMatrix[i, j] = eSlotState.Empty;
                }
            }
        }

        /// <summary>
        /// Check if a given column is free 
        /// </summary>
        /// <param name="i_column"></param>
        /// <returns></returns>
        private bool IsColumnFree(int i_column)
        {
            return (m_slotsMatrix[i_column, 0] == eSlotState.Empty);
        }

        /// <summary>
        /// Enum representing each board slot
        /// </summary>
        public enum eSlotState
        {
            Empty,
            Player1,
            Player2
        }
    }
}
