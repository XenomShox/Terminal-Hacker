using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

    enum Screen { MainMenu, Password, Win};
    Screen state = Screen.MainMenu;

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
        Terminal.WriteLine("Press 1 for NASA\n");
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

    }

    void RunMainMenu(string input)
    {
        if (input.ToLower() == "1")
        {
            level = 1;
            state = Screen.Password;
            startGame();
        }
        else if (input.ToLower() == "2")
        {
            level = 2;
            state = Screen.Password;
            startGame();
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

    private void startGame()
    {
        Terminal.WriteLine("You have choosed the level: " + level);
        Terminal.WriteLine("Please Enter your password: ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
