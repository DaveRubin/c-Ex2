using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class Menus
    {
        private const string k_DimensionsInputTemplate = "Please enter number of {0} between {1} and {2}";
        private const string k_MenuHeaderTemplate =
@"========================================================
* {0} *
* {1} *
========================================================
";
        private const string k_WordColumns = "columns";
        private const string k_WordRows = "rows";
        private const string k_DimensionsTitle = "Board dimensions selection";
        private const string k_DimensionsDescriptionTemplate = "Dimensions must be between {0}X{0} and {1}X{1} ";
        private const string k_GameModeTitle = "Game mode selection";
        private const string k_GameModeDescriptionTemplate = "Enter '{0}' for two players or '{1}' for human vs machine";
        private const char k_TwoPlayersSelectionKey = '1';
        private const char k_ManVsMachineSelectionKey = '2';
        private const string k_RestartGameMessage = @"Do you want another game? 
Press {0} if so, press {1} to exit.";
        private const char k_YesKey = 'y';
        private const char k_NoKey = 'n';
        private const string k_GoodByeMessage = @"Good bye, and thanks for playing


Press enter to exit";


        public static void GetBoardDimensions(out int i_columns, out int i_rows)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            int gameMinDimension = FourInARowGame.k_MinDimension;
            int gameMaxDimension = FourInARowGame.k_MaxDimension;

            string descriptionText = string.Format(k_DimensionsDescriptionTemplate, gameMinDimension, gameMaxDimension);
            Console.WriteLine(string.Format(k_MenuHeaderTemplate, k_DimensionsTitle, descriptionText));

            //get columns
            Console.WriteLine(string.Format(k_DimensionsInputTemplate, k_WordColumns, gameMinDimension, gameMaxDimension));
            i_columns = InputUtils.GetBoundedIntFromConsole(gameMinDimension, gameMaxDimension);

            //get rows
            Console.WriteLine(string.Format(k_DimensionsInputTemplate, k_WordRows, gameMinDimension, gameMaxDimension));
            i_rows = InputUtils.GetBoundedIntFromConsole(gameMinDimension, gameMaxDimension);
        }

        public static FourInARowGame.eGameMode GetGameMode()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            FourInARowGame.eGameMode selectedGameMode = FourInARowGame.eGameMode.ManVsMachine;
            string descriptionText = string.Format(k_GameModeDescriptionTemplate,
                k_TwoPlayersSelectionKey, k_ManVsMachineSelectionKey);
            Console.WriteLine(string.Format(k_MenuHeaderTemplate, k_GameModeTitle, descriptionText));

            char userInput = InputUtils.GetSepcificCharsFromConsole(k_TwoPlayersSelectionKey, k_ManVsMachineSelectionKey);

            if (userInput == k_TwoPlayersSelectionKey)
            {
                selectedGameMode = FourInARowGame.eGameMode.TwoPlayers;
            }

            return selectedGameMode;
        }

        public static void ShowWinScreen(string i_winnerName)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(string.Format("Player {0} wins !", i_winnerName));
        }

        public static void ShowTieScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("It's a tie!");
        }


        public static bool RestartGameMessage()
        {
            Console.WriteLine(string.Format(k_RestartGameMessage, k_YesKey, k_NoKey));
            char selectionChar = InputUtils.GetSepcificCharsFromConsole(k_YesKey, k_NoKey);
            return selectionChar == k_YesKey;
        }

        public static void GoodByeScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(k_GoodByeMessage);
            Console.ReadLine();
        }
    }
}
