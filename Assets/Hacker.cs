using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
    string[] passwords1 = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] passwords2 = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] passwords3 = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    string password;

    enum Screen { MainMenu, GuessPassword, Victory }
    Screen currentScreen;

	// Use this for initialization
	void Start () {
        showMainMenu();
	}

    void showMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello Hacker! What would you like to hack into?");
        Terminal.WriteLine("Press 1 to hack into the library!");
        Terminal.WriteLine("Press 2 to hack into the police station!");
        Terminal.WriteLine("Press 3 to hack into NASA!!!");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input) {
        if (input == "menu" || input == "MENU" || input == "Menu") {
            showMainMenu();
        } else if (input == "quit" || input == "exit" || input == "close") {
            Terminal.WriteLine("If on the web, please close the tab!");
            Application.Quit();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.GuessPassword) {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) {

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber) {
            level = int.Parse(input);
            ValidatePassword();
        } else if (input == "69") {
            Terminal.WriteLine("Redirecting to the nearest porn site...");
        } else {
            Terminal.WriteLine("Please choose a valid level");
            menuHint();
        }
    }

    void ValidatePassword()
    {
        currentScreen = Screen.GuessPassword;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        menuHint();
    }

    void SetRandomPassword() {
        switch (level)
        {
            case 1:
                password = passwords1[Random.Range(0, passwords1.Length)];
                break;
            case 2:
                password = passwords2[Random.Range(0, passwords2.Length)];
                break;
            case 3:
                password = passwords3[Random.Range(0, passwords3.Length)];
                break;
            default:
                Debug.LogError("Invalid level number!");
                break;
        }
    }

    void CheckPassword(string input) {
        if (input == password) {
            DisplayVictoryScreen();
        } else {
            ValidatePassword();
        }
    }

    void DisplayVictoryScreen() {
        currentScreen = Screen.Victory;
        Terminal.ClearScreen();
        showLevelReward();
    }

    void showLevelReward() {
        switch(level) {
            case 1:
                Terminal.WriteLine("Here's a book...");
                Terminal.WriteLine("Play again for a harder challenge!");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/"
                );
                menuHint();
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine("Play again for a harder challenge!");
                Terminal.WriteLine(@"
  __
 /0 \_______
 \__/-=' = '         
 "
                );
                menuHint();
                break;
            case 3:
                Terminal.WriteLine(@"
  _ __   __ _ ___  __ _
 | '_ \ / _` / __|/ _` |
 | | | | (_| \__ \ (_| |
 |_| |_|\__,_|___)\__,_|         
 "
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                menuHint();
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

    void menuHint()
    {
        Terminal.WriteLine("Type 'menu' to start over");
    }
}
