using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    GameObject playGame;
    GameObject quitGame;
    GameObject title;
    GameObject subTitle;

    // Use this for initialization
    void Start() {

        playGame = GameObject.FindGameObjectWithTag("PlayGameMenu");
        quitGame = GameObject.FindGameObjectWithTag("QuitGameMenu");
        title = GameObject.FindGameObjectWithTag("Title");
        subTitle = GameObject.FindGameObjectWithTag("SubTitle");

        if (LanguageManager.instance.language == 0) {
            playGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishNewGame;
            quitGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishQuitGame;
            title.GetComponentInChildren<Text>().text = LanguageManager.instance.englishTitle;
            subTitle.GetComponentInChildren<Text>().text = LanguageManager.instance.englishSubTitle;
        }
        if (LanguageManager.instance.language == 1) {
            playGame.GetComponentInChildren<Text>().text = LanguageManager.instance.danishNewGame;
            quitGame.GetComponentInChildren<Text>().text = LanguageManager.instance.danishQuitGame;
            title.GetComponentInChildren<Text>().text = LanguageManager.instance.danishTitle;
            subTitle.GetComponentInChildren<Text>().text = LanguageManager.instance.danishSubTitle;
        }
    }

    public void PlayGame() {

        playGame.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay());
        GameManager.instance.StartGame();
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(0.1f);
    }

    public void QuitGame() {
        quitGame.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay());
        Application.Quit();
    }
	public void ButtonClickSound(){
		GameManager.instance.buttonPressed ("button");
	}

    public void setDanish () {
        LanguageManager.instance.language = 1;
        playGame.GetComponentInChildren<Text>().text = LanguageManager.instance.danishNewGame;
        quitGame.GetComponentInChildren<Text>().text = LanguageManager.instance.danishQuitGame;
        title.GetComponentInChildren<Text>().text = LanguageManager.instance.danishTitle;
        subTitle.GetComponentInChildren<Text>().text = LanguageManager.instance.danishSubTitle;
    }

    public void setEnglish () {
        LanguageManager.instance.language = 0;
        playGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishNewGame;
        quitGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishQuitGame;
        title.GetComponentInChildren<Text>().text = LanguageManager.instance.englishTitle;
        subTitle.GetComponentInChildren<Text>().text = LanguageManager.instance.englishSubTitle;
    }
}
