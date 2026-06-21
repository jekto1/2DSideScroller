using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        AddChangeSceneListeners();
        DisableLockedLevel();
        CheckStartPanelExp();
    }

    #region Level Interface Management
    [Header("Level Selection Buttons")]
    public int levelCurrent;
    public Button[] levelButtons;

    public int sceneIndex = 0;
    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1;
            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }
    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelCurrent)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    #endregion



    #region Panel Management
    //Region ini mengatur agar start panel tidak muncul 2x
    [Header("Panel Start")]
    public GameObject startPanel;
    [Header("Panel Level")]
    public GameObject levelPanel;
    public void ShowStartPanel()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
    public void ShowLevelPanel() 
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
        GameManager.Instance.isStart = true;
    }

    private void CheckStartPanelExp()
    {
        if (isStart())
        {
            ShowLevelPanel();

        }
        else
        {
            ShowStartPanel();
        }
    }

    private bool isStart()
    {
        return GameManager.Instance.isStart;
    }
    #endregion


}