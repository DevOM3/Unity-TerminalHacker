using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;

    string password;
    string[] password1Array = { "cheetah", "monkey", "donkey", "banana" };
    string[] password2Array = { "Adilshah", "chatrapatiShivaji", "raje", "booksarelove", "halfgf"};
    string[] password3Array = { "nepotism", "criminals", "badprison", "magnum"};
    string[] password4Array = { "Hatinh", "pecado", "Nightmare", "SpaceShuttle", "solarEcllipse", "lunarstrike"};

    // Start is called before the first frame update
    void Start()
    {
        // calling function ShowMainMenu()
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowMainMenu()
    {
        // clearing the screen
        Terminal.ClearScreen();
        // writing the following statements to the Screen
        Terminal.WriteLine("Which system you want to break?\n");
        Terminal.WriteLine("Press 1 - School Library system");
        Terminal.WriteLine("Press 2 - Police Station Database");
        Terminal.WriteLine("Press 3 - Government Website");
        Terminal.WriteLine("Press 4 - NASA\n");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            level = 0;
            password = "";
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else if (input == "quit" || input == "exit" || input == "close")
        {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPass(input);
        }
    }

    private void RunMainMenu(string input)
    {
        if(input == "1" || input == "2" || input == "3" || input == "4")
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "menu")
        {
            level = 0;
            password = "";
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else
        {
            Terminal.WriteLine("\nWrong Input! Choose a valid level\n");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = password1Array[Random.Range(0, password1Array.Length)];
                break;
            case 2:
                password = password2Array[Random.Range(0, password1Array.Length)];
                break;
            case 3:
                password = password3Array[Random.Range(0, password1Array.Length)];
                break;
            case 4:
                password = password4Array[Random.Range(0, password1Array.Length)];
                break;
        }
        Terminal.WriteLine("Try to crack the password \n(Hint:  " + password.Anagram() + "):");
    }

    void CheckPass(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("\n\nAccess Granted!\n\n");
        }
        else if (input == "menu")
        {
            level = 0;
            password = "";
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else
        {
            Terminal.WriteLine("\nAccess Denied! Try again\n");
        }
    }
}
