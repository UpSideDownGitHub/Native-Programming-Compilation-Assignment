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
    public PlayerInput playerInput;

    [Header("Main Screen")]
    public GameObject mainScreen;
    public GameObject[] buttons;
    public int curSelected;

    [Header("Level Select Screen")]
    public GameObject levelSelectScreen;
    public GameObject sorter;
    public float moveAmmount;
    public int curLevel;
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
        curSelected = 0;
        curLevel = 0;
        playerInput = new();

        string movementRebind = PlayerPrefs.GetString("movementRebind", string.Empty);
        string aimRebind = PlayerPrefs.GetString("aimRebind", string.Empty);
        string shootRebind = PlayerPrefs.GetString("shootRebind", string.Empty);
        string pickupRebind = PlayerPrefs.GetString("PickupRebind", string.Empty);
        string dodgeRebind = PlayerPrefs.GetString("dodgeRebind", string.Empty);
        string throwRebind = PlayerPrefs.GetString("throwRebind", string.Empty);
        if (movementRebind == null || movementRebind == "")
        {
            string movementRebind2 = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("movementRebind", movementRebind2);
        }
        if (aimRebind == null || aimRebind == "")
        {
            string aimRebind2 = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("aimRebind", aimRebind2);
        }
        if (shootRebind == null || shootRebind == "")
        {
            string shootRebind2 = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("shootRebind", shootRebind2);
        }
        if (pickupRebind == null || pickupRebind == "")
        {
            string pickupRebind2 = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("pickupRebind", pickupRebind2);
        }
        if (dodgeRebind == null || dodgeRebind == "")
        {
            string dodgeRebind2 = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("dodgeRebind", dodgeRebind2);
        }
        if (throwRebind == null || throwRebind == "")
        {
            string throwRebind2 = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString("throwRebind", throwRebind2);
        }
        playerInput.Player_Map.Shoot.LoadBindingOverridesFromJson(movementRebind);
        playerInput.Player_Map.Shoot.LoadBindingOverridesFromJson(aimRebind);
        playerInput.Player_Map.Shoot.LoadBindingOverridesFromJson(shootRebind);
        playerInput.Player_Map.Shoot.LoadBindingOverridesFromJson(pickupRebind);
        playerInput.Player_Map.Shoot.LoadBindingOverridesFromJson(dodgeRebind);
        playerInput.Player_Map.Shoot.LoadBindingOverridesFromJson(throwRebind);
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
        string movementRebind = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
        string aimRebind = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
        string shootRebind = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
        string pickupRebind = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
        string dodgeRebind = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
        string throwRebind = playerInput.Player_Map.Pickup.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("movementRebind", movementRebind);
        PlayerPrefs.SetString("aimRebind", aimRebind);
        PlayerPrefs.SetString("shootRebind", shootRebind);
        PlayerPrefs.SetString("pickupRebind", pickupRebind);
        PlayerPrefs.SetString("dodgeRebind", dodgeRebind);
        PlayerPrefs.SetString("throwRebind", throwRebind);
    }

    public void StartRebinding(int action)
    {
        rebindingOperation = keyActions[action].action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .WithControlsExcluding(currentKeyText[0].text)
            .WithControlsExcluding(currentKeyText[1].text)
            .WithControlsExcluding(currentKeyText[2].text)
            .WithControlsExcluding(currentKeyText[3].text)
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(action))
            .Start();
    }

    private void RebindComplete(int action)
    {
        int bindingIndex = keyActions[action].action.GetBindingIndexForControl(keyActions[action].action.controls[0]);

        currentKeyText[action].text = InputControlPath.ToHumanReadableString(keyActions[action].action.bindings[bindingIndex].effectivePath,
                                                                                  InputControlPath.HumanReadableStringOptions.OmitDevice);

        rebindingOperation.Dispose();
    }

    public void OnEnable()
    {
        playerInput.Enable();
    }

    public void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainScreen.activeInHierarchy)
        {
            if (playerInput.Menus_Map.Up.WasPressedThisFrame() && curSelected > 0)
                curSelected--;
            else if (playerInput.Menus_Map.Down.WasPressedThisFrame() && curSelected < 2)
                curSelected++;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
        }
        else if (levelSelectScreen.activeInHierarchy && !prematureUpdateCall)
        {
            if (playerInput.Menus_Map.Left.WasPressedThisFrame() && curLevel > 0)
            {
                curLevel--;
                sorter.transform.position = new Vector3(sorter.transform.position.x + moveAmmount,
                                        sorter.transform.position.y,
                                        sorter.transform.position.z);
            }
            else if (playerInput.Menus_Map.Right.WasPressedThisFrame() && curLevel < sorter.transform.childCount - 1)
            {
                curLevel++;
                sorter.transform.position = new Vector3(sorter.transform.position.x - moveAmmount,
                                        sorter.transform.position.y,
                                        sorter.transform.position.z);
            }

            if (playerInput.Menus_Map.B.WasPressedThisFrame())
            {
                levelSelectScreen.SetActive(false);
                mainScreen.SetActive(true);
            }
            else if (playerInput.Menus_Map.A.WasPressedThisFrame())
            {
                levelSelectScreen.SetActive(false);
                levelInfo.SetActive(true);
                level = curLevel;
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
            if (playerInput.Menus_Map.B.WasPressedThisFrame())
            {
                levelInfo.SetActive(false);
                levelSelectScreen.SetActive(true);
                firstTime = true;
            }
            else if (playerInput.Menus_Map.A.WasPressedThisFrame())
            {
                //SceneManager.LoadSceneAsync(level + 1);
                Debug.Log("LOAD LEVEL: " + (level + 1).ToString());
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
                    if (playerInput.Menus_Map.Up.WasPressedThisFrame() && (curControlSetting == 1 ||
                                                           curControlSetting == 2 ||
                                                           curControlSetting == 4))
                        curControlSetting--;
                    else if (playerInput.Menus_Map.Down.WasPressedThisFrame() && (curControlSetting == 0 ||
                                                                                  curControlSetting == 1 ||
                                                                                  curControlSetting == 3))
                        curControlSetting++;
                    else if (playerInput.Menus_Map.Right.WasPressedThisFrame() && (curControlSetting == 1 ||
                                                                                  curControlSetting == 2))
                        curControlSetting += 2;
                    else if (playerInput.Menus_Map.Left.WasPressedThisFrame() && (curControlSetting == 3 ||
                                                                                  curControlSetting == 4))
                        curControlSetting -= 2;

                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(controlSettingButtons[curControlSetting]);

                    if (playerInput.Menus_Map.A.WasPressedThisFrame())
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

                if (playerInput.Menus_Map.B.WasPressedThisFrame())
                {
                    inSettings = false;
                }
            }
            else
            {
                if (playerInput.Menus_Map.Up.WasPressedThisFrame() && settingsCurSelected > 0)
                    settingsCurSelected--;
                else if (playerInput.Menus_Map.Down.WasPressedThisFrame() && settingsCurSelected < settingsButtons.Length - 1)
                    settingsCurSelected++;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(settingsButtons[settingsCurSelected]);

                if (playerInput.Menus_Map.B.WasPressedThisFrame())
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
