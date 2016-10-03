using UnityEngine;
using System.Collections;

public class LanguageManager {

    private static LanguageManager _instance;

    public string danishNewGame = "NYT SPIL";

    public string englishNewGame = "NEW GAME";
    public string englishQuitGame = "QUIT GAME";
    public string englishTitle = "JOURNEY THROUGH THE MIDNIGHT FOREST";
    public string englishSubTitle = "LOST PIGLETS";

    //getters:
    public static LanguageManager instance {
        get {
            if (_instance == null)
                _instance = new LanguageManager();
            return _instance;
        }
    }
}
