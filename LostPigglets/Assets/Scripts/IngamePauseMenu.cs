using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngamePauseMenu : MonoBehaviour {

    public static IngamePauseMenu instance;

    GameObject pauseMenu;
    GameObject resumeGame;
    GameObject mainMenu;
    GameObject restartGame;
    GameObject quitGame;


    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Use this for initialization
    void Start() {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        resumeGame = GameObject.FindGameObjectWithTag("ResumeGame");
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        restartGame = GameObject.FindGameObjectWithTag("RestartGame");
        quitGame = GameObject.FindGameObjectWithTag("QuitGame");


        if (LanguageManager.instance.language == 0) {
            resumeGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishResumeGamePause;
            mainMenu.GetComponentInChildren<Text>().text = LanguageManager.instance.englishMainMenuPause;
            restartGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishRestartGamePause;
            quitGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishQuitGamePause;
        }

        if(LanguageManager.instance.language == 1) {
            resumeGame.GetComponentInChildren<Text>().text = LanguageManager.instance.danishResumeGamePause;
            mainMenu.GetComponentInChildren<Text>().text = LanguageManager.instance.danishMainMenuPause;
            restartGame.GetComponentInChildren<Text>().text = LanguageManager.instance.danishRestartGamePause;
            quitGame.GetComponentInChildren<Text>().text = LanguageManager.instance.danishQuitGamePause;

        }

        pauseMenu.SetActive(false);
    }

    public void PauseGameMenu() {
        pauseMenu.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay(pauseMenu));

        GameManager.instance.isPaused = true;
        GameManager.instance.PauseGame();

        pauseMenu.SetActive(true);

    }


    IEnumerator Delay(GameObject obj) {
        yield return new WaitForSeconds(0.1f);
        obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void ResumeGame() {
        resumeGame.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay(resumeGame));
        GameManager.instance.isPaused = false;
        GameManager.instance.PauseGame();
        pauseMenu.SetActive(false);
    }

    public void MainMenu() {
        mainMenu.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay(mainMenu));
        GameManager.instance.LoadMainMenu();

    }

    public void RestartGame() {
        restartGame.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay(restartGame));
        GameManager.instance.RestartGame();

    }

    public void QuitGame() {
        quitGame.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay(quitGame));
        Application.Quit();
    }
}
