using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main()
    {
        // GLOBAL VARIABLES
        Random rnd = new Random();
        Console.OutputEncoding = Encoding.UTF8;

        // MENU CONSTANTS
        const string MenuTitleMsg = "===== MAIN MENU - CODEQUEST =====";
        const string MenuWelcomeUserMsg = "===== Welcome, {0} the {1} with level {2} =====";//NAME, TITLE, LEVEL
        const string MenuOption1Msg = "1. Train your wizard - Train the mage";
        const string MenuOption2Msg = "2. Increase LVL - Increase your level (max lvl 5)";
        const string MenuOption3Msg = "3";
        const string MenuOption4Msg = "4";
        const string MenuOption5Msg = "5";
        const string MenuOption6Msg = "6";
        const string MenuOption7Msg = "7";
        const string MenuOption0Msg = "0";
        const string MenuPromptMsg = "Choose an option (1-7) - (0) to exit: ";
        string[] MenuOptions = { MenuOption1Msg, MenuOption2Msg, MenuOption3Msg, MenuOption4Msg, MenuOption5Msg, MenuOption6Msg, MenuOption7Msg, MenuOption0Msg };

        // MENU VARIABLES
        int userMenuOption = 0;
        bool validInput = false;

        // CH1 - TRAIN WIZARD CONSTANTS
        const string NameInputMessage = "Enter the name of your wizard: ";
        const string DefaultWizardName = "Gandalf the Grey";
        const string NameInputErrorMessage = "\nError detected, default name assigned";
        const string TrainingSummaryMessage = "Day {0} -> {1}, you have already meditated for {2} hours and your power is now {3} points.";
        const string RankObtainedMsg = "Training complete! {0} has achieved a total power of {1} and earned the title '{2}'.";
        const string WizardRank0 = "Raoden el Elantrí";
        const string WizardRank1 = "Zyn el Buguejat";
        const string WizardRank2 = "Arka Nullpointer";
        const string WizardRank3 = "Elarion de les Brases";
        const string WizardRank4 = "ITB - Wizard el Gris";
        const int MaxWizardLevel = 5;

        // CH1 - TRAIN WIZARD VARIABLES
        string? wizardName = "";
        int wizardLevel = 1;
        string wizardRank = "";
        int trainingHours;
        int wizardPoints;
        string[] rankMessages =
                        {
                            "Repeteixes a 2a convocatòria.",
                            "Encara confons la vareta amb una cullera.",
                            "Ets un Invocador de Brises Màgiques.",
                            "Uau! Pots invocar dracs sense cremar el laboratori!",
                            "Has assolit el rang de Mestre dels Arcans!"
                        };

        // CH2 - Increase Lvl CONSTANTS
        const string MonsterDefeatMsg = "The {0} has been defeated!";
        const string LevelUpMsg = "Level Up!";
        const string MaxLevelMsg = "You have reached the maximum level.";
        const string MonsterAppearMsg = "A wild {0} appears!\nRoll the dice to attack.";
        const string MonsterStatsMsg = "The {0} has {1} HP.\nPress any key to roll the dice...";
        const string DiceRollMsg = "You rolled a {0}!";
        const string DiceDamageMsg = "The monster takes {0} of damage";
        const string DiceFace1 = @"
   _______
  /       /|
 /_______/ |
 |       | |
 |   o   | /
 |       |/
 '-------'";

        const string DiceFace2 = @"
   _______
  /       /|
 /_______/ |
 | o     | |
 |       | /
 |     o |/
 '-------'";

        const string DiceFace3 = @"
   _______
  /       /|
 /_______/ |
 | o     | |
 |   o   | /
 |     o |/
 '-------'";

        const string DiceFace4 = @"
   _______
  /       /|
 /_______/ |
 | o   o | |
 |       | /
 | o   o |/
 '-------'";

        const string DiceFace5 = @"
   _______
  /       /|
 /_______/ |
 | o   o | |
 |   o   | /
 | o   o |/
 '-------'";

        const string DiceFace6 = @"
   _______
  /       /|
 /_______/ |
 | o   o | |
 | o   o | /
 | o   o |/
 '-------'";

        // CH2 - Increase Lvl VARIABLES
        string[] monstersNames = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍", "Ancient Dragon 🐉", "Cat 🐱" };
        int[] monstersHP = { 3, 5, 10, 11, 18, 15, 20, 50, 1 };
        string[] diceFaces = { DiceFace1, DiceFace2, DiceFace3, DiceFace4, DiceFace5, DiceFace6 };

        // CH3 - Loot the mine CONSTANTS
        const string MineEmptySymbol = "➖";
        const string MineCoinSymbol = "🪙";
        const string MineNothingSymbol = "❌";

        // CH3 - Loot the mine VARIABLES
        int digAttempts;
        int[,] mineMap = new int[5, 5];
        string[,] mineMapDisplay = new string[5, 5];


        do
        {
            Console.WriteLine("🪙");
            Console.WriteLine(MenuTitleMsg);
            if (!string.IsNullOrWhiteSpace(wizardRank) && !string.IsNullOrWhiteSpace(wizardName))
            {
                Console.WriteLine(MenuWelcomeUserMsg, wizardName, wizardRank, wizardLevel);
            }
            foreach (string option in MenuOptions)
            {
                Console.WriteLine(option);
            }
            Console.Write(MenuPromptMsg);

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
                        try
                        {
                            Console.Write(NameInputMessage);
                            wizardName = Console.ReadLine();
                            if (string.IsNullOrEmpty(wizardName))
                            {
                                Console.WriteLine(NameInputErrorMessage);
                                wizardName = DefaultWizardName;
                            }
                            wizardName = char.ToUpper(wizardName[0]) + wizardName.Substring(1).ToLower();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex + NameInputErrorMessage);
                            wizardName = DefaultWizardName;
                        }

                        wizardPoints = 0;
                        for (int i = 1; i < 6; i++)
                        {
                            trainingHours = rnd.Next(24);
                            wizardPoints = wizardPoints + rnd.Next(1, 10);
                            Console.WriteLine(TrainingSummaryMessage, i, wizardName, trainingHours, wizardPoints);
                        }

                        if (wizardPoints < 20)
                        {
                            wizardRank = WizardRank0;
                            Console.WriteLine(rankMessages[0]);
                        }
                        else if (wizardPoints >= 20 && wizardPoints < 30)
                        {
                            wizardRank = WizardRank1;
                            Console.WriteLine(rankMessages[1]);
                        }
                        else if (wizardPoints >= 30 && wizardPoints < 35)
                        {
                            wizardRank = WizardRank2;
                            Console.WriteLine(rankMessages[2]);
                        }
                        else if (wizardPoints >= 35 && wizardPoints < 40)
                        {
                            wizardRank = WizardRank3;
                            Console.WriteLine(rankMessages[3]);
                        }
                        else if (wizardPoints >= 40)
                        {
                            wizardRank = WizardRank4;
                            Console.WriteLine(rankMessages[4]);
                        }
                        Console.WriteLine(RankObtainedMsg, wizardName, wizardPoints, wizardRank);
                        break;
                    case 2:
                        int rndMonsterIndex = rnd.Next(0, monstersNames.GetLength(0));
                        int monsterHP = monstersHP[rndMonsterIndex];
                        string monsterName = monstersNames[rndMonsterIndex];
                        int diceRoll;
                        Console.WriteLine(MonsterAppearMsg, monsterName);
                        while (monsterHP > 0)
                        {
                            Console.WriteLine(MonsterStatsMsg, monsterName, monsterHP);
                            Console.ReadKey();
                            diceRoll = rnd.Next(1, 7);
                            Console.WriteLine(DiceRollMsg, diceRoll);
                            Console.WriteLine(diceFaces[diceRoll - 1]);
                            Console.WriteLine(DiceDamageMsg, diceRoll);
                            monsterHP -= diceRoll;
                        }
                        if (wizardLevel < MaxWizardLevel)
                        {
                            Console.WriteLine(MonsterDefeatMsg, monsterName);
                            Console.WriteLine(LevelUpMsg);
                            wizardLevel++;
                        }
                        else
                        {
                            Console.WriteLine(MonsterDefeatMsg, monsterName);
                            Console.WriteLine(MaxLevelMsg);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < mineMap.GetLength(0); i++)
                        {
                            for (int j = 0; j < mineMap.GetLength(1); j++)
                            {
                                mineMapDisplay[i, j] = MineEmptySymbol;
                                mineMap[i, j] = rnd.Next(0, 2) == 0 ? 0 : 1; // 0 = nothing, 1 = coin
                            }
                        }
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