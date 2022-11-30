//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Input Systems/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Player_Map"",
            ""id"": ""e6f6510c-643f-4a37-a667-18ded47831a5"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""59791c65-8cd8-4cf2-a514-32d037735a53"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""ee5efbd6-6e98-414c-bb2b-8f7f10cf73e8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Value"",
                    ""id"": ""3d6f6f2a-0006-4879-96ef-4b260df9d8d6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""eb551581-87d0-4802-9df4-0f530f7dcaaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9c22cf6c-49a2-4811-9d4c-a7ffd330b11a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""ed9b8d3c-985c-479e-8cd2-98ffc7e28786"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""6c9b66d8-0bf8-4876-85f2-3d31fce3d59e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PvP_WeaponSwapLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ecc5990e-695c-4d14-a0d6-a4af9964aa9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PvP_WeaponSwapRight"",
                    ""type"": ""Button"",
                    ""id"": ""b9387764-88a7-4c38-8d47-83bbe0384ab9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PvP_Shoot2"",
                    ""type"": ""Button"",
                    ""id"": ""a72dd228-e1ea-4627-a81b-09c563e8c525"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PvP_Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""6d51d189-9077-4ce0-9279-11cc49582eb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""673a7952-1e99-4252-8bc4-f8784a5eecdd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""28b46d67-e282-4a4b-8a4c-a64f0695ff91"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c0681cdc-96e5-497d-be55-463dd722df35"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""968dec0d-04de-403c-869b-301754026eea"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3f82f0d2-9cfb-41df-b402-e6cd49e77655"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50759fc8-cb27-489b-85a2-55d526353b04"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fa089825-c124-4850-9aa0-63e219d1017b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5ace2d07-a340-4a4a-8b48-7ad9e2686998"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1b5002c0-4ce2-4faa-a38e-59c8d185d021"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c89a2a79-d9db-47f6-b214-196d29e4ed91"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d8d3194-6f3f-4fde-88d5-8258f56ff8a7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be25bcf6-96e8-47b1-91b7-d6458d41118e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17f88af1-628b-4732-b247-5e0f8307bb16"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94039e73-4ce2-42a5-b06f-2f81646a8340"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0113af9d-0a10-4cdb-b214-aae28436edf6"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccbf5078-a0e1-4522-b470-e84f2c8ce0fc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""548fdf14-f1db-4d9b-b75d-b280e8aeb6d7"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72a7b33c-ebe7-434f-9161-b9202ca2c26f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60ebb146-67c0-408f-bb2f-ce4b55ba42a4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PvP_WeaponSwapLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b24f6d7-26c8-4b3f-91ed-d88ada35f2f9"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PvP_WeaponSwapRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1c51355-da60-4103-9708-c42c4b2a9a0b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PvP_Shoot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7494bb9-a04d-4673-89a4-d6132e7e99f3"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PvP_Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus_Map"",
            ""id"": ""9dc92f00-9651-470b-a1b0-fb8e1e66f52b"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""3fec430a-2461-45a0-b4c3-af30ae246061"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""e8250459-4566-4802-a32f-c239af43f72a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""fcbf05da-2a8f-4afd-84ce-e36b458d6e00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""3fadee67-e0c9-41e9-b3db-7664139bf398"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""7a923941-13a7-43f7-9d90-1acb2e254400"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""0564c5c4-e092-4ce0-a938-c9f79a4002c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f49a6b30-4eae-48f6-a602-0d6d9b039fe8"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46fff16b-a3a7-435e-9bfb-27266e3907aa"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50350166-5303-4307-a20d-141774149c60"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da0374c9-823a-47d1-b4d2-eba37234082d"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ba38913-9781-4ea7-a1ea-066a6aeac707"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be02a564-d6d4-41dc-9d95-c75fd6c343f3"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5e130f7-c365-48e9-a116-fa01594c2752"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7749e69-70ab-460c-b606-7728ec6b280f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9032a9bd-41d4-4132-9970-151db2b1614d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e28a3083-d5fe-45f9-a431-9f650c77f695"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PvP"",
            ""bindingGroup"": ""PvP"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player_Map
        m_Player_Map = asset.FindActionMap("Player_Map", throwIfNotFound: true);
        m_Player_Map_Movement = m_Player_Map.FindAction("Movement", throwIfNotFound: true);
        m_Player_Map_Mouse = m_Player_Map.FindAction("Mouse", throwIfNotFound: true);
        m_Player_Map_Pickup = m_Player_Map.FindAction("Pickup", throwIfNotFound: true);
        m_Player_Map_Throw = m_Player_Map.FindAction("Throw", throwIfNotFound: true);
        m_Player_Map_Shoot = m_Player_Map.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Map_Dodge = m_Player_Map.FindAction("Dodge", throwIfNotFound: true);
        m_Player_Map_Pause = m_Player_Map.FindAction("Pause", throwIfNotFound: true);
        m_Player_Map_PvP_WeaponSwapLeft = m_Player_Map.FindAction("PvP_WeaponSwapLeft", throwIfNotFound: true);
        m_Player_Map_PvP_WeaponSwapRight = m_Player_Map.FindAction("PvP_WeaponSwapRight", throwIfNotFound: true);
        m_Player_Map_PvP_Shoot2 = m_Player_Map.FindAction("PvP_Shoot2", throwIfNotFound: true);
        m_Player_Map_PvP_Dodge = m_Player_Map.FindAction("PvP_Dodge", throwIfNotFound: true);
        // Menus_Map
        m_Menus_Map = asset.FindActionMap("Menus_Map", throwIfNotFound: true);
        m_Menus_Map_Up = m_Menus_Map.FindAction("Up", throwIfNotFound: true);
        m_Menus_Map_Down = m_Menus_Map.FindAction("Down", throwIfNotFound: true);
        m_Menus_Map_Left = m_Menus_Map.FindAction("Left", throwIfNotFound: true);
        m_Menus_Map_Right = m_Menus_Map.FindAction("Right", throwIfNotFound: true);
        m_Menus_Map_A = m_Menus_Map.FindAction("A", throwIfNotFound: true);
        m_Menus_Map_B = m_Menus_Map.FindAction("B", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player_Map
    private readonly InputActionMap m_Player_Map;
    private IPlayer_MapActions m_Player_MapActionsCallbackInterface;
    private readonly InputAction m_Player_Map_Movement;
    private readonly InputAction m_Player_Map_Mouse;
    private readonly InputAction m_Player_Map_Pickup;
    private readonly InputAction m_Player_Map_Throw;
    private readonly InputAction m_Player_Map_Shoot;
    private readonly InputAction m_Player_Map_Dodge;
    private readonly InputAction m_Player_Map_Pause;
    private readonly InputAction m_Player_Map_PvP_WeaponSwapLeft;
    private readonly InputAction m_Player_Map_PvP_WeaponSwapRight;
    private readonly InputAction m_Player_Map_PvP_Shoot2;
    private readonly InputAction m_Player_Map_PvP_Dodge;
    public struct Player_MapActions
    {
        private @PlayerInputs m_Wrapper;
        public Player_MapActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Map_Movement;
        public InputAction @Mouse => m_Wrapper.m_Player_Map_Mouse;
        public InputAction @Pickup => m_Wrapper.m_Player_Map_Pickup;
        public InputAction @Throw => m_Wrapper.m_Player_Map_Throw;
        public InputAction @Shoot => m_Wrapper.m_Player_Map_Shoot;
        public InputAction @Dodge => m_Wrapper.m_Player_Map_Dodge;
        public InputAction @Pause => m_Wrapper.m_Player_Map_Pause;
        public InputAction @PvP_WeaponSwapLeft => m_Wrapper.m_Player_Map_PvP_WeaponSwapLeft;
        public InputAction @PvP_WeaponSwapRight => m_Wrapper.m_Player_Map_PvP_WeaponSwapRight;
        public InputAction @PvP_Shoot2 => m_Wrapper.m_Player_Map_PvP_Shoot2;
        public InputAction @PvP_Dodge => m_Wrapper.m_Player_Map_PvP_Dodge;
        public InputActionMap Get() { return m_Wrapper.m_Player_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_MapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_MapActions instance)
        {
            if (m_Wrapper.m_Player_MapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMovement;
                @Mouse.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMouse;
                @Pickup.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPickup;
                @Throw.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnThrow;
                @Shoot.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnShoot;
                @Dodge.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnDodge;
                @Pause.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPause;
                @PvP_WeaponSwapLeft.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_WeaponSwapLeft;
                @PvP_WeaponSwapLeft.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_WeaponSwapLeft;
                @PvP_WeaponSwapLeft.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_WeaponSwapLeft;
                @PvP_WeaponSwapRight.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_WeaponSwapRight;
                @PvP_WeaponSwapRight.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_WeaponSwapRight;
                @PvP_WeaponSwapRight.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_WeaponSwapRight;
                @PvP_Shoot2.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_Shoot2;
                @PvP_Shoot2.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_Shoot2;
                @PvP_Shoot2.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_Shoot2;
                @PvP_Dodge.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_Dodge;
                @PvP_Dodge.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_Dodge;
                @PvP_Dodge.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnPvP_Dodge;
            }
            m_Wrapper.m_Player_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @PvP_WeaponSwapLeft.started += instance.OnPvP_WeaponSwapLeft;
                @PvP_WeaponSwapLeft.performed += instance.OnPvP_WeaponSwapLeft;
                @PvP_WeaponSwapLeft.canceled += instance.OnPvP_WeaponSwapLeft;
                @PvP_WeaponSwapRight.started += instance.OnPvP_WeaponSwapRight;
                @PvP_WeaponSwapRight.performed += instance.OnPvP_WeaponSwapRight;
                @PvP_WeaponSwapRight.canceled += instance.OnPvP_WeaponSwapRight;
                @PvP_Shoot2.started += instance.OnPvP_Shoot2;
                @PvP_Shoot2.performed += instance.OnPvP_Shoot2;
                @PvP_Shoot2.canceled += instance.OnPvP_Shoot2;
                @PvP_Dodge.started += instance.OnPvP_Dodge;
                @PvP_Dodge.performed += instance.OnPvP_Dodge;
                @PvP_Dodge.canceled += instance.OnPvP_Dodge;
            }
        }
    }
    public Player_MapActions @Player_Map => new Player_MapActions(this);

    // Menus_Map
    private readonly InputActionMap m_Menus_Map;
    private IMenus_MapActions m_Menus_MapActionsCallbackInterface;
    private readonly InputAction m_Menus_Map_Up;
    private readonly InputAction m_Menus_Map_Down;
    private readonly InputAction m_Menus_Map_Left;
    private readonly InputAction m_Menus_Map_Right;
    private readonly InputAction m_Menus_Map_A;
    private readonly InputAction m_Menus_Map_B;
    public struct Menus_MapActions
    {
        private @PlayerInputs m_Wrapper;
        public Menus_MapActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Menus_Map_Up;
        public InputAction @Down => m_Wrapper.m_Menus_Map_Down;
        public InputAction @Left => m_Wrapper.m_Menus_Map_Left;
        public InputAction @Right => m_Wrapper.m_Menus_Map_Right;
        public InputAction @A => m_Wrapper.m_Menus_Map_A;
        public InputAction @B => m_Wrapper.m_Menus_Map_B;
        public InputActionMap Get() { return m_Wrapper.m_Menus_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Menus_MapActions set) { return set.Get(); }
        public void SetCallbacks(IMenus_MapActions instance)
        {
            if (m_Wrapper.m_Menus_MapActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnRight;
                @A.started -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_Menus_MapActionsCallbackInterface.OnB;
            }
            m_Wrapper.m_Menus_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
            }
        }
    }
    public Menus_MapActions @Menus_Map => new Menus_MapActions(this);
    private int m_PvPSchemeIndex = -1;
    public InputControlScheme PvPScheme
    {
        get
        {
            if (m_PvPSchemeIndex == -1) m_PvPSchemeIndex = asset.FindControlSchemeIndex("PvP");
            return asset.controlSchemes[m_PvPSchemeIndex];
        }
    }
    public interface IPlayer_MapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnPvP_WeaponSwapLeft(InputAction.CallbackContext context);
        void OnPvP_WeaponSwapRight(InputAction.CallbackContext context);
        void OnPvP_Shoot2(InputAction.CallbackContext context);
        void OnPvP_Dodge(InputAction.CallbackContext context);
    }
    public interface IMenus_MapActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
    }
}
