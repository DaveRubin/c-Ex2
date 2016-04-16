using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class Menus
    {

        /// <summary>
        /// Print board dimensions menu
        /// </summary>
        /// <param name="i_columns"></param>
        /// <param name="i_rows"></param>
        public static void GetBoardDimensions(out int i_columns, out int i_rows)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.ForegroundColor = GameColors.k_MenuHeadersColor;

            int gameMinDimension = FourInARowGame.k_MinDimension;
            int gameMaxDimension = FourInARowGame.k_MaxDimension;
            string descriptionText = string.Format(GameTexts.k_DimensionsDescriptionTemplate, gameMinDimension, gameMaxDimension);

            Console.WriteLine(string.Format(GameTexts.k_MenuHeaderTemplate, GameTexts.k_DimensionsTitle, descriptionText));

            //get columns
            Console.WriteLine(string.Format(GameTexts.k_DimensionsInputTemplate, GameTexts.k_WordColumns, gameMinDimension, gameMaxDimension));
            i_columns = InputUtils.GetBoundedIntFromConsole(gameMinDimension, gameMaxDimension);

            //get rows
            Console.WriteLine(string.Format(GameTexts.k_DimensionsInputTemplate, GameTexts.k_WordRows, gameMinDimension, gameMaxDimension));
            i_rows = InputUtils.GetBoundedIntFromConsole(gameMinDimension, gameMaxDimension);

            Console.ForegroundColor = GameColors.k_BaseColor;
        }

        /// <summary>
        /// Prints game mode menu
        /// </summary>
        /// <returns></returns>
        public static FourInARowGame.eGameMode GetGameMode()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.ForegroundColor = GameColors.k_MenuHeadersColor;
            FourInARowGame.eGameMode selectedGameMode = FourInARowGame.eGameMode.ManVsMachine;
            string descriptionText = string.Format(GameTexts.k_GameModeDescriptionTemplate,
                GameTexts.k_TwoPlayersSelectionKey, GameTexts.k_ManVsMachineSelectionKey);
            Console.WriteLine(string.Format(GameTexts.k_MenuHeaderTemplate, GameTexts.k_GameModeTitle, descriptionText));

            char userInput = InputUtils.GetSepcificCharsFromConsole(GameTexts.k_TwoPlayersSelectionKey, GameTexts.k_ManVsMachineSelectionKey);

            if (userInput == GameTexts.k_TwoPlayersSelectionKey)
            {
                selectedGameMode = FourInARowGame.eGameMode.TwoPlayers;
            }

            Console.ForegroundColor = GameColors.k_BaseColor;
            return selectedGameMode;
        }

        /// <summary>
        /// Prints win screen, adds winner name to screen template
        /// </summary>
        /// <param name="i_winnerName"></param>
        public static void ShowWinScreen(string i_winnerName)
        {
            Console.ForegroundColor = GameColors.k_WinColor;
            Ex02.ConsoleUtils.Screen.Clear();

            Console.WriteLine(string.Format(GameTexts.k_WinScreenTemplate, i_winnerName));
            Console.ReadLine();
            Console.ForegroundColor = GameColors.k_BaseColor;
        }

        /// <summary>
        /// Prints Tie screen
        /// </summary>
        public static void ShowTieScreen()
        {
            Console.ForegroundColor = GameColors.k_TieColor;
            Ex02.ConsoleUtils.Screen.Clear();

            Console.WriteLine(GameTexts.k_TieScreen);
            Console.ReadLine();
            Console.ForegroundColor = GameColors.k_BaseColor;
        }

        /// <summary>
        /// Prints restart messgae and returns user selection (weather to restart of exit)
        /// </summary>
        /// <param name="m_players"></param>
        /// <returns></returns>
        public static bool RestartGameMessage(List<Player> i_playersList)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(
                string.Format(
                    GameTexts.k_RestartGameScreenTemplate,
                    i_playersList[0].r_name,
                    i_playersList[0].Score,
                    i_playersList[1].r_name,
                    i_playersList[1].Score,
                    GameTexts.k_YesKey,
                    GameTexts.k_NoKey));
            char selectionChar = InputUtils.GetSepcificCharsFromConsole(GameTexts.k_YesKey, GameTexts.k_NoKey);
            return selectionChar == GameTexts.k_YesKey;
        }

        public static void GoodByeScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(GameTexts.k_GoodByeMessage);
            Console.ReadLine();
        }
    }
}
