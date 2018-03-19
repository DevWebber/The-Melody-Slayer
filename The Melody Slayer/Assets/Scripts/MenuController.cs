using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    /// <summary>
    /// This controller was designed specifically to work for both scenes, as the methods
    /// called will only be called if they work for that scene. This saves both code and effort.
    /// Some methods are also called in both scenes, making this practical
    /// </summary>
    private int scenePicked;
    private bool firstTime = true;

    private GameObject persistantObject;
    private PersistantVariables persistantVariable;

    [SerializeField]
    private CanvasGroup mainCanvas;
    [SerializeField]
    private CanvasGroup levelCanvas;
    [SerializeField]
    private CanvasGroup controlCanvas;
    [SerializeField]
    private CanvasGroup introCanvas;

    [SerializeField]
    private Text selectionText;
    [SerializeField]
    private Text controlText;

/*    [SerializeField]
    private Text totalInsectKillText;
    [SerializeField]
    private Text singleRunInsectKillText;
    [SerializeField]
    private Text resetButtonText;
    [SerializeField]
    private Text totalSurvivedText;
*/

    [SerializeField]
    private Text bestScoreOne;

    [SerializeField]
    private GameObject[] toggleButtons;


    void Start()
    {
        //Ensure things can move;
        Time.timeScale = 1;
        //Gets a reference to the persistant object
        persistantObject = GameObject.Find("PersistanceObject");
        if (persistantObject != null)
        {
            persistantVariable = persistantObject.GetComponent<PersistantVariables>();
        }
        else
        {
           // Debug.Log("PERSISTANT OBJECT NOT FOUND");
        }

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            //UpdatePersistantValues();
        }
    }

    private void UpdatePersistantValues()
    {
        bestScoreOne.text = "Best Score: " + persistantVariable.levelOneTopScore.ToString("F2");
        //bestTimeHard.text = "Best Time: " + persistantVariable.timeSurvivedHard.ToString("F2") + " seconds";
        //bestTimeExpert.text = "Best Time: " + persistantVariable.timeSurvivedExpert.ToString("F2") + " seconds";
        //bestTimeLimitBreak.text = "Best Time: " + persistantVariable.timeSurvivedLimitBreak.ToString("F2") + " seconds";

        //totalInsectKillText.text = "Insects Killed: " + persistantVariable.totalInsectsKilled;
        //singleRunInsectKillText.text = "Insects Killed (single run): " + persistantVariable.highestInsectsKilled;

/*      for (int i = 0; i < toggleButtons.Length; i++)
        {
            switch (toggleButtons[i].name)
            {
                case "ToggleFreeAim":
                    if (persistantVariable.freeAim)
                    {
                        toggleButtons[i].GetComponent<Toggle>().isOn = true;
                    }
                    break;
                case "ToggleFpsCount":
                    if (persistantVariable.fpsCounterEnabled)
                    {
                        toggleButtons[i].GetComponent<Toggle>().isOn = true;
                    }
                    break;

                case "ToggleHunger":
                    if (persistantVariable.hungerEnabled)
                    {
                        toggleButtons[i].GetComponent<Toggle>().isOn = true;
                    }
                    break;
            }
    
        }*/
    }

    public void LevelSelectMenu(CanvasGroup menuTo)
    {
        //Loads and sets three two canvases to save us having an entire scene for level selection
        if (menuTo.name == "StartButtons")
        {
            SwitchMenu(mainCanvas, true);
            SwitchMenu(levelCanvas, false);
            SwitchMenu(controlCanvas, false);
            SwitchMenu(introCanvas, false);
        }
        else if (menuTo.name == "LevelSelect")
        {
            SwitchMenu(mainCanvas, false);
            SwitchMenu(levelCanvas, true);
        }
        else if (menuTo.name == "Controls/Options")
        {
            SwitchMenu(mainCanvas, false);
            SwitchMenu(controlCanvas, true);
        }
        else if (menuTo.name == "IntroSequence")
        {
            SwitchMenu(mainCanvas, false);
            SwitchMenu(introCanvas, true);
        }
    }

    private void SwitchMenu(CanvasGroup menu, bool enableState)
    {
        if (enableState)
        {
            menu.alpha = 1;
            menu.interactable = true;
            menu.blocksRaycasts = true;
        }
        else
        {
            menu.alpha = 0;
            menu.interactable = false;
            menu.blocksRaycasts = false;
        }
    }

    //These methods are universal. Works for both scenes
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

/*    public void ResetScores()
    {
        if (firstTime)
        {
            resetButtonText.text = "Are you sure?";
            Invoke("ResetDelay", 0.5f);
        }
        else
        {
            persistantVariable.highestInsectsKilled = 0;
            persistantVariable.totalInsectsKilled = 0;

            persistantVariable.timeSurvivedNormal = 0.00f;
            persistantVariable.timeSurvivedHard = 0.00f;
            persistantVariable.timeSurvivedExpert = 0.00f;

            UpdatePersistantValues();

            firstTime = true;
            resetButtonText.text = "Reset Scores";
        }

    }
*/
    private void ResetDelay()
    {
        firstTime = false;
    }
    //
    public void SceneSelection(string difficultyType)
    {
        //Another switch statement for setting difficulty.
        switch (difficultyType)
        {
            case "Normal":
                //persistantVariable.difficultySetting = 1;
                break;
            case "Hard":
                //persistantVariable.difficultySetting = 2;
                break;
            case "Expert":
                //persistantVariable.difficultySetting = 3;
                break;
            default:
                //persistantVariable.difficultySetting = 1;
                break;
        }
        Invoke("StartGame", 0.5f);
    }

    //This is used to switch between the two firing modes. 
    public void AimModeSelection(bool isFreeAim)
    {
        if (isFreeAim)
        {
            //persistantVariable.freeAim = true;
        }
        else
        {
            //persistantVariable.freeAim = false;
        }
    }

    //Allows hovering over buttons to reveal what they do. Nice UI feedback.
    public void OnButtonHover(string difficultyType)
    {
        //Switch statements save me so much code, It's great.
        switch (difficultyType)
        {
            case "Normal":
                selectionText.text = "The regular difficulty. Play if its your first time";
                break;
            case "Hard":
                selectionText.text = "More obstacles and slightly faster. Reccomended mode";
                break;
            case "Expert":
                selectionText.text = "What have I done";
                break;
            case "LimitBreak":
                selectionText.text = "True Dodging Hell";
                break;
            default:
                selectionText.text = "Select the Difficulty";
                break;
        }

    }

    //Changes text to whatever is currently hovered on
    public void OnButtonHoverControls(string optionType)
    {
        switch (optionType)
        {
            case "FreeAim":
                controlText.text = "Enable Free aiming mode, which allows mouse aiming (Not fully working)";
                break;
            case "FPSCounter":
                controlText.text = "Shows the current frames per second";
                break;
            case "Hunger":
                controlText.text = "Enable or Disable Hunger Mode";
                break;
            default:
                controlText.text = "The Extra Options above are not reccomended";
                break;
        }
    }

    public void OnButtonExit()
    {
        selectionText.text = "Select the difficulty";
    }

    public void OnButtonExitControl()
    {
        controlText.text = "The Extra Options above are not reccomended";
    }
}
