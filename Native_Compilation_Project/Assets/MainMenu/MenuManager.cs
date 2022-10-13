using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public PlayerInput playerInput;
    [Header("Main Screen")]
    public GameObject mainScreen;
    public GameObject[] buttons;
    public int curSelected;
    
    // Start is called before the first frame update
    void Awake()
    {
        curSelected = 0;
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
        /*
        if (playerInput.Menus_Map.A.WasPerformedThisFrame())
        {
            buttons[curSelected].GetComponent<Button>().onClick.Invoke();
        }
        */

        if (playerInput.Menus_Map.Up.WasPressedThisFrame() && curSelected > 0)
            curSelected--;
        else if (playerInput.Menus_Map.Down.WasPressedThisFrame() && curSelected < 2)
            curSelected++;

        Debug.Log(curSelected);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
    }

    public void TestButton()
    {
        Debug.Log("BUTTON PRESSED");
    }
}
