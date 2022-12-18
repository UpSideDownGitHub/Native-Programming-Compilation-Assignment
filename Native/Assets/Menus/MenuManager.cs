using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference Up;
    public InputActionReference Down;
    public InputActionReference Left;
    public InputActionReference Right;
    public InputActionReference A;
    public InputActionReference B;

    [Header("Main Screen")]
    public GameObject mainScreen;
    public GameObject[] buttons;
    public int curSelected;

    [Header("Level Select Screen")]
    public GameObject levelSelectScreen;
    public GameObject sorter;
    public float moveAmmount;
    public int curLevel;
    public int[] currentLevelSceneIndex;
    private bool prematureUpdateCall = false;

    [Header("Level Info Screen")]
    public GameObject levelInfo;
    public int level;
    private bool firstTime = true;
    public TMP_Text levelName;
    public TMP_Text levelInfoText;
    public Image levelImage;

    [Header("Settings Screen")]
    public GameObject settingsScreen;
    public GameObject[] settingsButtons;
    public int settingsCurSelected;
    private bool inSettings = false;

    [Header("General Settings")]
    public GameObject settingsGeneralOptions;

    [Header("Sound Settings")]
    public GameObject settingsSoundOptions;

    [Header("Controls Settings")]
    public GameObject settingsControlOptions;
    public GameObject[] controlSettingButtons;
    public TMP_Text[] currentKeyText;
    public InputActionReference[] keyActions;
    public int curControlSetting;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    // Start is called before the first frame update
    void Awake()
    {
        moveAmmount = Screen.width;
        curSelected = 0;
        curLevel = 0;

        string savedInput = PlayerPrefs.GetString("Controls2", string.Empty);
        if (string.IsNullOrEmpty(savedInput))
        {
            Save();
            savedInput = PlayerPrefs.GetString("Controls2", string.Empty);
        }
        playerInput.actions.LoadBindingOverridesFromJson(savedInput);
        loadCurrentKeybinds();
    }
    public void loadCurrentKeybinds()
    {
        for (int i = 0; i < currentKeyText.Length; i++)
        {
            int bindingIndex = keyActions[i].action.GetBindingIndexForControl(keyActions[i].action.controls[0]);
            currentKeyText[i].text = InputControlPath.ToHumanReadableString(keyActions[i].action.bindings[bindingIndex].effectivePath,
                                                                             InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
    }
    public void Save()
    {
        string currentInputs = playerInput.actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("Controls2", currentInputs);
    }

    public void StartRebinding(int action)
    {
        rebindingOperation = keyActions[action].action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .WithControlsExcluding(keyActions[0].action.bindings[keyActions[0].action.GetBindingIndexForControl(keyActions[0].action.controls[0])].effectivePath)
            .WithControlsExcluding(keyActions[1].action.bindings[keyActions[1].action.GetBindingIndexForControl(keyActions[1].action.controls[0])].effectivePath)
            .WithControlsExcluding(keyActions[2].action.bindings[keyActions[2].action.GetBindingIndexForControl(keyActions[2].action.controls[0])].effectivePath)
            .WithControlsExcluding(keyActions[3].action.bindings[keyActions[3].action.GetBindingIndexForControl(keyActions[3].action.controls[0])].effectivePath)
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(action))
            .Start();
    }

    private void RebindComplete(int action)
    {
        int bindingIndex = keyActions[action].action.GetBindingIndexForControl(keyActions[action].action.controls[0]);

        currentKeyText[action].text = InputControlPath.ToHumanReadableString(keyActions[action].action.bindings[bindingIndex].effectivePath,
                                                                                  InputControlPath.HumanReadableStringOptions.OmitDevice);
        Save();
        rebindingOperation.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainScreen.activeInHierarchy)
        {
            if (Up.action.WasPressedThisFrame() && curSelected > 0)
                curSelected--;
            else if (Down.action.WasPressedThisFrame() && curSelected < 3)
                curSelected++;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
        }
        else if (levelSelectScreen.activeInHierarchy && !prematureUpdateCall)
        {
            if (Left.action.WasPressedThisFrame() && curLevel > 0)
            {
                curLevel--;
                sorter.transform.position = new Vector3(sorter.transform.position.x + moveAmmount,
                                        sorter.transform.position.y,
                                        sorter.transform.position.z);
            }
            else if (Right.action.WasPressedThisFrame() && curLevel < sorter.transform.childCount - 1)
            {
                curLevel++;
                sorter.transform.position = new Vector3(sorter.transform.position.x - moveAmmount,
                                        sorter.transform.position.y,
                                        sorter.transform.position.z);
            }

            if (B.action.WasPressedThisFrame())
            {
                levelSelectScreen.SetActive(false);
                mainScreen.SetActive(true);
            }
            else if (A.action.WasPressedThisFrame())
            {
                levelSelectScreen.SetActive(false);
                levelInfo.SetActive(true);
                level = currentLevelSceneIndex[curLevel];
            }
        }
        else if (levelInfo.activeInHierarchy)
        {
            if (firstTime)
            {
                // load all of the basic elements in (the level info)
                levelName.text = "Level " + (curLevel + 1).ToString();
                levelInfoText.text = "THIS IS A PLACE HOLDER FOR THE ACTUAL DESCRIPTION\n" + (curLevel + 1).ToString();
                //levelImage.sprite = Sprite;
                firstTime = false;
            }
            if (B.action.WasPressedThisFrame())
            {
                levelInfo.SetActive(false);
                levelSelectScreen.SetActive(true);
                firstTime = true;
            }
            else if (A.action.WasPressedThisFrame())
            {
                SceneManager.LoadSceneAsync(level);
                Debug.Log("LOAD LEVEL: " + (level).ToString());
            }
        }
        else if (settingsScreen.activeInHierarchy && !prematureUpdateCall)
        {
            if (inSettings)
            {
                if (settingsGeneralOptions.activeInHierarchy)
                {

                }
                else if (settingsSoundOptions.activeInHierarchy)
                {

                }
                else if (settingsControlOptions.activeInHierarchy)
                {
                    if (Up.action.WasPressedThisFrame() && (curControlSetting == 1 ||
                                                           curControlSetting == 3))
                        curControlSetting--;
                    else if (Down.action.WasPressedThisFrame() && (curControlSetting == 0 ||
                                                                   curControlSetting == 2))
                        curControlSetting++;
                    else if (Right.action.WasPressedThisFrame() && (curControlSetting == 0 ||
                                                                    curControlSetting == 1))
                        curControlSetting += 2;
                    else if (Left.action.WasPressedThisFrame() && (curControlSetting == 2 ||
                                                                   curControlSetting == 3))
                        curControlSetting -= 2;

                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(controlSettingButtons[curControlSetting]);

                    if (A.action.WasPressedThisFrame())
                    {
                        if (curControlSetting == 0)
                        {
                            // swap the input of the movement and aim
                            Debug.Log("Movement & Aim");
                        }
                        else if (curControlSetting == 1)
                        {
                            // call the record new input for the shoot function
                            Debug.Log("Shoot");
                        }
                        else if (curControlSetting == 2)
                        {
                            // call the record new input for the pickup function
                            Debug.Log("Pickup");
                        }
                        else if (curControlSetting == 3)
                        {
                            // call the record new input for the dodge function
                            Debug.Log("Dodge");
                        }
                        else if (curControlSetting == 4)
                        {
                            // call the record new input for the throw function
                            Debug.Log("Throw");
                        }
                    }
                }

                if (B.action.WasPressedThisFrame())
                {
                    inSettings = false;
                }
            }
            else
            {
                if (Up.action.WasPressedThisFrame() && settingsCurSelected > 0)
                    settingsCurSelected--;
                else if (Down.action.WasPressedThisFrame() && settingsCurSelected < settingsButtons.Length - 1)
                    settingsCurSelected++;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(settingsButtons[settingsCurSelected]);

                if (B.action.WasPressedThisFrame())
                {
                    settingsScreen.SetActive(false);
                    mainScreen.SetActive(true);
                }
            }
        }
        prematureUpdateCall = false;
    }

    public void SettingsGeneralPressed()
    {
        settingsGeneralOptions.SetActive(true);
        settingsSoundOptions.SetActive(false);
        settingsControlOptions.SetActive(false);
        inSettings = true;
        prematureUpdateCall = true;
    }
    public void SettingsSoundPressed()
    {
        settingsGeneralOptions.SetActive(false);
        settingsSoundOptions.SetActive(true);
        settingsControlOptions.SetActive(false);
        inSettings = true;
        prematureUpdateCall = true;
    }
    public void SettingsControlsPressed()
    {
        settingsGeneralOptions.SetActive(false);
        settingsSoundOptions.SetActive(false);
        settingsControlOptions.SetActive(true);
        inSettings = true;
        prematureUpdateCall = true;
    }

    public void PlayPressed()
    {
        mainScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
        prematureUpdateCall = true;
    }

    public void PvPPressed()
    {
        SceneManager.LoadSceneAsync(16);
    }
    public void SettingsPressed()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        prematureUpdateCall = true;
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
