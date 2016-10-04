using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour {

    GameObject retry;
    GameObject mainMenu;

    // Use this for initialization
    void Start() {

        StartCoroutine(Fade());

        retry = GameObject.FindGameObjectWithTag("RetryButton");
        mainMenu = GameObject.FindGameObjectWithTag("MainMenuButton");

        if (LanguageManager.instance.language == 0) {
            retry.GetComponentInChildren<Text>().text = LanguageManager.instance.englishRetryWin;
            mainMenu.GetComponentInChildren<Text>().text = LanguageManager.instance.englishMainMenuWin;
        }

        if (LanguageManager.instance.language == 1) {
            retry.GetComponentInChildren<Text>().text = LanguageManager.instance.danishRetryWin;
            mainMenu.GetComponentInChildren<Text>().text = LanguageManager.instance.danishMainMenuWin;
        }
    }

    public void RetryGame() {
        retry.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay(retry));
        GameManager.instance.StartGame();

    }

    public void MainMenu() {
        mainMenu.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay(mainMenu));
        GameManager.instance.LoadMainMenu();
    }

    IEnumerator Delay(GameObject obj) {
        yield return new WaitForSeconds(0.1f);
        obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    IEnumerator Fade() {
        float fadeTime = GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Fading>().BeginFade(-1);
        yield return new WaitForSeconds(fadeTime);
    }

}
