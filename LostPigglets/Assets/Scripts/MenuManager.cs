using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    GameObject playGame;
    GameObject quitGame;
    GameObject title;
    GameObject subTitle;

	// Use this for initialization
	void Start () {

        playGame = GameObject.FindGameObjectWithTag("PlayGameMenu");
        quitGame = GameObject.FindGameObjectWithTag("QuitGameMenu");
        title = GameObject.FindGameObjectWithTag("Title");
        subTitle = GameObject.FindGameObjectWithTag("SubTitle");

        playGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishNewGame;
        quitGame.GetComponentInChildren<Text>().text = LanguageManager.instance.englishQuitGame;
        title.GetComponentInChildren<Text>().text = LanguageManager.instance.englishTitle;
        subTitle.GetComponentInChildren<Text>().text = LanguageManager.instance.englishSubTitle;

    }

    public void PlayGame() {
                
        playGame.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
        StartCoroutine(Delay());
        SceneManager.LoadScene("Development");
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(0.2f);
    }

    public void QuitGame() {
        quitGame.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(Delay());
        Application.Quit();
    }
}
