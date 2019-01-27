using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject TutorialScreen;
    public GameObject CreditsScreen;
    public GameObject StartButton;

    private void Start()
    {
        StartButton.GetComponent<Button>().Select();
    }
    public void ShowTutorial()
    {
        TutorialScreen.SetActive(true);
        TutorialScreen.GetComponent<Button>().Select();
    }

    public void ShowCredits()
    {
        CreditsScreen.SetActive(true);
        CreditsScreen.GetComponent<Button>().Select();
    }

    public void ReturnToMain()
    {
        CreditsScreen.SetActive(false);
        StartButton.GetComponent<Button>().Select();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
