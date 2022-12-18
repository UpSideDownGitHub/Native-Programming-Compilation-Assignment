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
    [Header("########################################")]
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference Up;
    public InputActionReference Down;
    public InputActionReference Left;
    public InputActionReference Right;
    public InputActionReference A;
    public InputActionReference B;

    [Header("########################################")]
    [Header("Main Screen")]
    public GameObject mainScreen;
    public GameObject[] buttons;
    public int curSelected;

    [Header("########################################")]
    [Header("Level Select Screen")]
    public GameObject levelSelectScreen;
    public GameObject sorter;
    public float moveAmmount;
    public int curLevel;
    public int[] currentLevelSceneIndex;
    private bool prematureUpdateCall = false;

    [Header("########################################")]
    [Header("Level Info Screen")]
    public GameObject levelInfo;
    public int level;
    private bool firstTime = true;
    public TMP_Text levelName;
    public TMP_Text levelInfoText;
    public Image levelImage;

    [Header("########################################")]
    [Header("Credits Screen")]
    public GameObject creditsUI;

    [Header("########################################")]
    [Header("Settings Screen")]
    public GameObject settingsScreen;
    public GameObject[] settingsButtons;
    public int settingsCurSelected;
    private bool inSettings = false;

    [Header("########################################")]
    [Header("General Settings")]
    public GameObject settingsGeneralOptions;
    public GameObject[] generalSettingsButtons;
    public int curGeneralSetting;

    [Header("########################################")]
    [Header("Sound Settings")]
    public GameObject settingsSoundOptions;
    public GameObject[] soundSettingsButtons;
    public int curSoundSetting;

    [Header("########################################")]
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

        // custom controls
        string savedInput = PlayerPrefs.GetString("Controls2", string.Empty);
        if (string.IsNullOrEmpty(savedInput))
        {
            Save();
            savedInput = PlayerPrefs.GetString("Controls2", string.Empty);
        }
        playerInput.actions.LoadBindingOverridesFromJson(savedInput);
        loadCurrentKeybinds();

        // Set Sensitivity Slider
        Slider sensitivitySlider = generalSettingsButtons[0].GetComponent<Slider>();
        float savedSensitivity = PlayerPrefs.GetFloat("Sensitivity", float.MinValue);
        if (savedSensitivity == float.MinValue)
        {
            PlayerPrefs.SetFloat("Sensitivity", 1);
            savedSensitivity = PlayerPrefs.GetFloat("Sensitivity", float.MinValue);
        }
        sensitivitySlider.value = savedSensitivity;

        // Set Volume Sliders
        Slider musicVolumeSlider = soundSettingsButtons[0].GetComponent<Slider>();
        Slider sfxVolumeSlider = soundSettingsButtons[1].GetComponent<Slider>();
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", float.MinValue);
        float savedsfxVolume = PlayerPrefs.GetFloat("SFXVolume", float.MinValue);
        if (savedMusicVolume == float.MinValue)
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", float.MinValue);
        }
        if (savedsfxVolume == float.MinValue)
        {
            PlayerPrefs.SetFloat("SFXVolume", 1);
            savedsfxVolume = PlayerPrefs.GetFloat("SFXVolume", float.MinValue);
        }
        musicVolumeSlider.value = savedMusicVolume;
        sfxVolumeSlider.value = savedsfxVolume;

        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 0);


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
            inMainScreenMenu();
        }
        else if (levelSelectScreen.activeInHierarchy && !prematureUpdateCall)
        {
            inLevelSelectMenu();
        }
        else if (levelInfo.activeInHierarchy)
        {
            inLevelInfoMenu();
        }
        else if (settingsScreen.activeInHierarchy && !prematureUpdateCall)
        {
            inSettingsMenu();
        }
        else if (creditsUI.activeInHierarchy && !prematureUpdateCall)
        {
            inCreditsMenu();
        }
        prematureUpdateCall = false;
    }

    public void inMainScreenMenu()
    {
        if (Up.action.WasPressedThisFrame() && curSelected > 0)
            curSelected--;
        else if (Down.action.WasPressedThisFrame() && curSelected < buttons.Length - 1)
            curSelected++;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
    }

    public void inLevelSelectMenu()
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
    public void inLevelInfoMenu()
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
            SceneLoadingManager.instance.loadscene(level);
            Debug.Log("LOAD LEVEL: " + (level).ToString());
        }
    }
    public void inSettingsMenu()
    {
        if (inSettings)
        {
            if (settingsGeneralOptions.activeInHierarchy)
            {
                if (Up.action.WasPressedThisFrame() && curGeneralSetting > 0)
                    curGeneralSetting--;
                else if (Down.action.WasPressedThisFrame() && curGeneralSetting < generalSettingsButtons.Length - 1)
                    curGeneralSetting++;

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(generalSettingsButtons[curGeneralSetting]);

                if (Right.action.IsPressed())
                {
                    Slider slider = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>();
                    if (slider != null)
                    {
                        if (slider.value < slider.maxValue)
                        {
                            slider.value += 0.005f;
                        }
                    }
                }
                else if (Left.action.IsPressed())
                {
                    Slider slider = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>();
                    if (slider != null)
                    {
                        if (slider.value > slider.minValue)
                        {
                            slider.value -= 0.005f;
                        }
                    }
                }
            }
            else if (settingsSoundOptions.activeInHierarchy)
            {
                if (Up.action.WasPressedThisFrame() && curSoundSetting > 0)
                    curSoundSetting--;
                else if (Down.action.WasPressedThisFrame() && curSoundSetting < soundSettingsButtons.Length-1)
                    curSoundSetting++;

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(soundSettingsButtons[curSoundSetting]);

                if (Right.action.IsPressed())
                {
                    Slider slider = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>();
                    if (slider != null)
                    {
                        if (slider.value < slider.maxValue)
                        {
                            slider.value += 0.005f;
                        }
                    }
                }
                else if (Left.action.IsPressed())
                {
                    Slider slider = EventSystem.current.currentSelectedGameObject.GetComponent<Slider>();
                    if (slider != null)
                    {
                        if (slider.value > slider.minValue)
                        {
                            slider.value -= 0.005f;
                        }
                    }
                }
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
                // SAVE THE SETTINGS
                // Set Sensitivity Slider
                Slider sensitivitySlider = generalSettingsButtons[0].GetComponent<Slider>();
                PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);

                // Set Volume Sliders
                Slider musicVolumeSlider = soundSettingsButtons[0].GetComponent<Slider>();
                Slider sfxVolumeSlider = soundSettingsButtons[1].GetComponent<Slider>();
                PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
                PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);

                gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 0);

                settingsScreen.SetActive(false);
                mainScreen.SetActive(true);
            }
        }
    }

    public void inCreditsMenu()
    {
        if (B.action.WasPressedThisFrame())
        {
            creditsUI.SetActive(false);
            mainScreen.SetActive(true);
        }
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
        SceneLoadingManager.instance.loadscene(16);
    }

    public void TutorialPressed()
    {
        SceneLoadingManager.instance.loadscene(1);
    }

    public void SettingsPressed()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        prematureUpdateCall = true;
    }

    public void CreditsPressed()
    {
        mainScreen.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
