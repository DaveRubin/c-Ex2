using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class Board
    {
        public readonly int r_rows;
        public readonly int r_columns;
        private eSlotState[,] slotsMatrix;

        private const char P1Symbol = 'O';
        private const char P2Symbol = 'X';
        private const char EmptySymbol = ' ';
        private const string SlotTemplate = @"  {0}  ";
        private const char TableHorizontalSeperatorChar = '|';
        private const char TableVerticalSeperatorChar = '=';

        public bool IsFull
        {
            get
            {
                bool result = true;
                for (int i = 0; i < r_columns; i++)
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
            r_rows = i_rows;
            r_columns = i_columns;
            slotsMatrix = new eSlotState[i_columns, i_rows];
            EmptyBoard();
        }



        /// <summary>
        /// Clear screen and Prints the board 
        /// </summary>
        public void PrintBoard()
        {
            StringBuilder separatorRow = new StringBuilder();
            int seperatorRowLength = r_columns * (SlotTemplate.Length - 1) + 1;
            separatorRow.Append(TableVerticalSeperatorChar, seperatorRowLength);

            Ex02.ConsoleUtils.Screen.Clear();
            PrintHeaderRow();
            for (int row = 0; row < r_rows; row++)
            {
                for (int column = 0; column < r_columns; column++)
                {
                    eSlotState slotType = slotsMatrix[column, row];

                    if (column == 0)
                    {
                        Console.Write(TableHorizontalSeperatorChar);
                    }

                    Printslot(slotType);
                    Console.Write(TableHorizontalSeperatorChar);

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
            for (int column = 0; column < r_columns; column++)
            {
                Console.Write(string.Format(SlotTemplate, column + 1));
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
            char slotPieceView = EmptySymbol;
            switch (i_slotType)
            {
                case  eSlotState.Empty:
                    slotPieceView = EmptySymbol;
                    break;
                    
                case  eSlotState.Player1:
                    slotPieceView = P1Symbol;
                    break;
                
                case eSlotState.Player2:
                    slotPieceView = P2Symbol;
                    break;
            }

            Console.Write(string.Format(SlotTemplate,slotPieceView));
        }

        //add piece to column , 
        //return false if column is full
        public bool AddPieceToColumn(int i_column, eSlotState i_pieceType)
        {
            bool success = true;

            if (IsColumnFree(i_column))
            {
                int targetRow = r_rows - 1;

                while (slotsMatrix[i_column, targetRow] != eSlotState.Empty)
                {
                    targetRow--;
                }

                slotsMatrix[i_column, targetRow] = i_pieceType;
            }
            else
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Set all slots to be "Empty"
        /// </summary>
        public void EmptyBoard()
        {
            for (int i = 0; i < r_columns; i++)
            {
                for (int j = 0; j < r_rows; j++)
                {
                    slotsMatrix[i, j] = eSlotState.Empty;
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
            return (slotsMatrix[i_column, 0] == eSlotState.Empty);
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
