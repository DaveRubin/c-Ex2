using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    /// <summary>
    /// Container class for all messages and string templates used in game
    /// </summary>
    internal class GameTexts
    {
        public const string k_DimensionsInputTemplate = "Please enter number of {0} between {1} and {2}";
        public const string k_MenuHeaderTemplate =
@"========================================================
* {0} *
* {1} *
========================================================
";
        public const string k_WordColumns = "columns";
        public const string k_WordRows = "rows";
        public const string k_DimensionsTitle = "Board dimensions selection";
        public const string k_DimensionsDescriptionTemplate = "Dimensions must be between {0}X{0} and {1}X{1} ";
        public const string k_GameModeTitle = "Game mode selection";
        public const string k_GameModeDescriptionTemplate = "Enter '{0}' for two players or '{1}' for human vs machine";
        public const char k_TwoPlayersSelectionKey = '1';
        public const char k_ManVsMachineSelectionKey = '2';
        public const string k_WinScreenTemplate = 
@"=========================================================

            Great success!!!
             {0} wins !


        Press enter to continue
=========================================================";
        public const string k_TieScreen =
@"=========================================================

            It's a tie!!!!
           everybody loses!


        Press enter to continue
=========================================================";
        public const string k_RestartGameScreenTemplate =
@"=========================================================

                current score:
                --------------
            {0}:{1} -- {2}:{3} 

            Do you want another game? 
            -'{4}' to play another game
            -'{5}' to exit.

=========================================================";
        public const char k_YesKey = 'y';
        public const char k_NoKey = 'n';
        public const string k_GoodByeMessage = @"
=======================================
=                                     =
=                                     =
=             Good bye!               =
=       And thanks for playing        =
=                                     =
=                                     =
=        press 'enter' to exit        =
=                                     =
=                                     =
=======================================";
    }
}
