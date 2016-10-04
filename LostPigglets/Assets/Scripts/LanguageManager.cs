using UnityEngine;
using System.Collections;

public class LanguageManager {

    private static LanguageManager _instance;

    //Danish Main Menu
    public string danishNewGame = "NYT SPIL";
    public string danishQuitGame = "AFSLUT SPIL";
    public string danishTitle = "TUREN GENNEM MIDNATSSKOVEN";
    public string danishSubTitle = "DE FORSVUNDNE GRISLINGE";

    //English Main Menu
    public string englishNewGame = "NEW GAME";
    public string englishQuitGame = "QUIT GAME";
    public string englishTitle = "JOURNEY THROUGH THE MIDNIGHT FOREST";
    public string englishSubTitle = "LOST PIGLETS";

    //Danish Pause Menu
    public string danishMainMenuPause = "HOVEDMENU";
    public string danishResumeGamePause = "FORTSÆT SPIL";
    public string danishRestartGamePause = "GENSTART SPIL";
    public string danishQuitGamePause = "AFSLUT SPIL";

    //English Pause Menu
    public string englishMainMenuPause = "MAIN MENU";
    public string englishResumeGamePause = "RESUME GAME";
    public string englishRestartGamePause = "RESTART GAME";
    public string englishQuitGamePause = "QUIT GAME";

    //Change Language
    public string changeToDk = "DK";
    public string changeToEn = "EN";

    // 0 = English, 1 = danish
    public int language = 0;


    //getters:
    public static LanguageManager instance {
        get {
            if (_instance == null)
                _instance = new LanguageManager();
            return _instance;
        }
    }

    public void setLanguage() {

        if(language == 0) {
            language = 1;
        }
        if(language == 1) {
            language = 0;
        }
    }
}
