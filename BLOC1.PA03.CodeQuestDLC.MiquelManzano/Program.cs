public class Program
{
    public static void Main()
    {
        // MENU CONSTANTS
        const string MenuTitleMsg = "===== MAIN MENU - CODEQUEST =====";
        const string MenuWelcomeUserMsg = "===== Welcome, {0} the {1} with level {2} =====";//NAME, TITLE, LEVEL
        const string MenuOption1Msg = "1";
        const string MenuOption2Msg = "2";
        const string MenuOption3Msg = "3";
        const string MenuOption4Msg = "4";
        const string MenuOption5Msg = "5";
        const string MenuOption6Msg = "6";
        const string MenuOption7Msg = "7";
        const string MenuOption0Msg = "0";
        string[] MenuOptions = { MenuOption1Msg, MenuOption2Msg, MenuOption3Msg, MenuOption4Msg, MenuOption5Msg, MenuOption6Msg, MenuOption7Msg, MenuOption0Msg };

        // MENU VARIABLES
        int userMenuOption = 0;
        bool validInput = false;

        do
        {
            Console.WriteLine(MenuTitleMsg);
            foreach (string option in MenuOptions)
            {
                Console.WriteLine(option);
            }

            try
            {
                validInput = true;
                userMenuOption = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("MenuInputErrorMessage");
                validInput = false;
            }
            catch (Exception)
            {
                Console.WriteLine("MenuInputErrorMessage");
                validInput = false;
            }
            if (validInput)
            {
                switch (userMenuOption)
                {
                    case 1:
                        Console.WriteLine("Option1Message");
                        break;
                    case 2:
                        Console.WriteLine("Option2Message");
                        break;
                    case 0:
                        Console.WriteLine("ExitMessage");
                        break;
                    default:
                        Console.WriteLine("Not valid option");
                        break;
                }
            }
        } while(userMenuOption != 0);
    }
}