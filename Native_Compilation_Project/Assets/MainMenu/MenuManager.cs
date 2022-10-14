using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

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


    // Start is called before the first frame update
    void Awake()
    {
        curSelected = 0;
        curLevel = 0;
        playerInput = new();
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
                LevelInfo();
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
        prematureUpdateCall = false;
    }

    public void LevelInfo()
    {

    }

    public void PlayPressed()
    {
        mainScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
        prematureUpdateCall = true;
    }
}
