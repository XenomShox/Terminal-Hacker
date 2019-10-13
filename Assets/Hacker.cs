using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

    enum Screen { MainMenu, Password, Win};
    Screen state = Screen.MainMenu;

    string password;

    string[] level1password = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2password = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3password = { "starfield", "telescope", "environement", "exploration", "astronauts" };

    // Start is called before the first frame update
    void Start()
    {
        showMainMenu();
    }

    void showMainMenu()
    {
        state = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA\n");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input.ToLower() == "menu")
        {
            showMainMenu();
        }
        else if(state == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(state == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void CheckPassword(string input)
    {
        if (input.ToLower() == password.ToLower())
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        state = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
         ________
        /_______//
       /_______//
      /_______//
     /_______//
    (_______(/
"
                );
                Terminal.WriteLine("\nYou may type menu at any time.");
                break;
            case 2:
                Terminal.WriteLine("Greeting citizen");
                Terminal.WriteLine(@"
      ,   /\   ,
     / '-'  '-' \
    |   POLICE   |
    \    .--.    /
     |  ( 19 )  |
     \   '--'   /
      '--.  .--'
          \/
                ");
                Terminal.WriteLine("\nYou may type menu at any time.");
                break;
            case 3:
                Terminal.WriteLine(@"
     _ __   __ _ ___  __ _ 
    | '_ \ / _` / __|/ _` |
    | | | | (_| \__ \ (_| |
    |_| |_|\__,_|___/\__,_|
                ");
                Terminal.WriteLine("\nWelcome to NASA's internal system!");
                Terminal.WriteLine("You may type menu at any time.");
                break;
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input.ToLower() == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid Level");
        }
    }

    void AskForPassword()
    {
        state = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1password[Random.Range(0, level1password.Length)];
                break;
            case 2:
                password = level2password[Random.Range(0, level2password.Length)];
                break;
            case 3:
                password = level3password[Random.Range(0, level3password.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
