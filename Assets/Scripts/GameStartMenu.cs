using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject startPanel;
    public GameObject options;
    public GameObject about;
    public GameObject tutorialPanel;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button startButtonSchool;
    public Button startButtonGarage;
    public Button optionButton;
    public Button aboutButton;
    public Button quitButton;

    public Button tutorContinue;
    public Button tutorCancel;

    public List<Button> returnButtons;

    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(EnableStart);
        startButtonSchool.onClick.AddListener(StartGameSchool);
        startButtonGarage.onClick.AddListener(StartGameGarage);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);
        tutorContinue.onClick.AddListener(ContinueGame);
        tutorCancel.onClick.AddListener(CancelGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGameSchool()
    {
        HideAll();
        // SceneTransitionManager.singleton.GoToSceneAsync(1);
        // SceneManager.LoadScene(1);
        sceneIndex = 1;
        EnableTutorial();
    }

    public void StartGameGarage()
    {
        HideAll();
        // SceneTransitionManager.singleton.GoToSceneAsync(2);
        // SceneManager.LoadScene(2);
        sceneIndex = 2;
        EnableTutorial();
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
        startPanel.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
        startPanel.SetActive(false);
    }
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
        startPanel.SetActive(false);
    }
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
        startPanel.SetActive(false);
    }
    public void EnableStart()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
        startPanel.SetActive(true);
    }

    public void EnableTutorial()
    {
        HideAll();
        tutorialPanel.SetActive(true);
    }

    public void ContinueGame()
    {
        HideAll();
        SceneManager.LoadScene(sceneIndex);
    }

    public void CancelGame()
    {
        HideAll();
        EnableMainMenu();
    }

}
