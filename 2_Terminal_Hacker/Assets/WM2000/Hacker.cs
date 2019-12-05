using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Screen
{
  MainMenu,
  Password,
  Win
};

public class Hacker : MonoBehaviour
{
  // Game configuration
  string[][] passwords = {
    new string[] {"books", "aisle", "shelf", "password", "font", "borrow"},
    new string[] {"prisoner", "handcuffs", "holster", "uniform", "arrest"}
  };

  // Game state
  Screen currentScreen;
  int level;
  string password;

  // Start is called before the first frame update
  void Start()
  {
    ShowMainMenu();
  }

  void OnUserInput(string input)
  {
    if (input == "menu")
    {
      ShowMainMenu();
    }
    else if (currentScreen == Screen.MainMenu)
    {
      RunMainMenu(input);
    }
    else if (currentScreen == Screen.Password)
    {
      RunPasswordScreen(input);
    }
  }

  void ShowMainMenu()
  {
    currentScreen = Screen.MainMenu;
    Terminal.ClearScreen();

    Terminal.WriteLine("Hello Tim");
    Terminal.WriteLine("What would you like to hack into?");
    Terminal.WriteLine("Press 1 for the local library");
    Terminal.WriteLine("Press 2 for the police station");
    Terminal.WriteLine("Enter your selection:");
  }

  void RunMainMenu(string input)
  {
    switch (input)
    {
      case "1":
      case "2":
        ShowPasswordScreen(input);
        break;

      case "007":
        Terminal.WriteLine("Select a level, Mr. Bond.");
        break;

      default:
        Terminal.WriteLine("Choose a valid level.");
        break;
    }
  }

  void ShowPasswordScreen(string input)
  {
    currentScreen = Screen.Password;
    level = int.Parse(input);
    password = passwords[level - 1][Random.Range(0, passwords[level - 1].Length)];

    Terminal.ClearScreen();
    Terminal.WriteLine("You have chosen level " + level);
    Terminal.WriteLine("Enter your password: " + password.Anagram());
    Terminal.WriteLine("Type \"menu\" to return to the main menu.");
  }

  void RunPasswordScreen(string input)
  {
    if (input == password)
    {
      ShowWinScreen();
    } else
    {
      Terminal.WriteLine("Wrong!");
    }
  }

  void ShowWinScreen()
  {
    currentScreen = Screen.Win;

    Terminal.ClearScreen();

    switch (level)
    {
      case 1:
        Terminal.WriteLine("Well done, noob.");
        break;

      case 2:
        Terminal.WriteLine("Well done, sir.");
        break;
    }

    Terminal.WriteLine("Type \"menu\" to return to the main menu.");
  }
}
