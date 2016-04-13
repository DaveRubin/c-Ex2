﻿using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    class Board
    {
        private readonly int m_rows;
        private readonly int m_columns;
        private eSlotState[,] slotsMatrix;

        private const char P1Symbol = 'O';
        private const char P2Symbol = 'X';
        private const char EmptySymbol = ' ';

        private const string SlotTemplate = @"  {0}  ";
        private const char TableHorizontalSeperatorChar = '|';
        private const char TableVerticalSeperatorChar = '=';


        //on construction, create the new matrix and initialize memebers
        public Board(int i_columns, int i_rows )
        {
            m_rows = i_rows;
            m_columns = i_columns;
            slotsMatrix = new eSlotState[i_columns, i_rows];
            ClearBoard();
            PrintBoard();
        }

        /// <summary>
        /// Clear screen and draw board again 
        /// </summary>
        public void UpdateBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            PrintBoard();
        }

        public void PrintBoard()
        {
            StringBuilder separatorRow = new StringBuilder();
            int seperatorRowLength = m_columns * (SlotTemplate.Length - 1) + 1;
            separatorRow.Append(TableVerticalSeperatorChar, seperatorRowLength);
            PrintHeaderRow();
            for (int row = 0; row < m_rows; row++)
            {
                for (int column = 0; column < m_columns; column++)
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

        private void PrintHeaderRow()
        {
            Console.Write(' ');
            for (int column = 0; column < m_columns; column++)
            {
                Console.Write(string.Format(SlotTemplate, column));
                Console.Write(' ');
            }
            Console.Write(Environment.NewLine);
        }

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

        //Set all slots to "empty"
        public void ClearBoard()
        {
            for (int i = 0; i < m_columns; i++)
            {
                for (int j = 0; j < m_rows; j++)
                {
                    slotsMatrix[i, j] = eSlotState.Empty;
                }
            }
        }

        //returns an array containing the indexes of the free columns
        public List<int> GetFreeColumns()
        {
            List<int> freeColumns = new List<int>();

            for (int i = 0; i < m_columns; i++)
            {
                if (IsColumnFree(i))
                {
                    freeColumns.Add(i);
                }
            }

            return freeColumns;
        }

        //add piece to column , 
        //return false if column is full
        public bool AddPieceToColumn(int i_column, eSlotState i_pieceType)
        {
            bool success = true;

            if (IsColumnFree(i_column))
            {
                int targetRow = m_rows - 1;

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
