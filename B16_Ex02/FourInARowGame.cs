using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    class FourInARowGame
    {
        public FourInARowGame()
        {
            Board b = new Board(5,4);
            Console.ReadLine();
            b.AddPieceToColumn(2, Board.eSlotState.Player1);
            b.AddPieceToColumn(2, Board.eSlotState.Player2);
            b.AddPieceToColumn(2, Board.eSlotState.Player1);
            b.AddPieceToColumn(2, Board.eSlotState.Player1);
            b.AddPieceToColumn(2, Board.eSlotState.Player1);
            b.UpdateBoard();
            Console.ReadLine();
            b.AddPieceToColumn(0, Board.eSlotState.Player1);
            b.AddPieceToColumn(1, Board.eSlotState.Player2);
            b.AddPieceToColumn(3, Board.eSlotState.Player1);
            b.AddPieceToColumn(0, Board.eSlotState.Player2);
            b.UpdateBoard();
        }
    }
}
