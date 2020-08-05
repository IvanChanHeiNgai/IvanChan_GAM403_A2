// GENERATED AUTOMATICALLY FROM 'Assets/_Everything/_Code/_Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @_Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""_Input"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""6fd9359e-7906-4845-b6c2-3c3c0cc6a260"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""777ead02-c826-4a54-9d4e-2c4b74da1e71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""28331263-41e2-4775-adda-d92c72130953"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""69df04fe-f829-4bad-862b-2aa67ab76c20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""d5eee8cf-278c-49ef-a01a-363ac5bf6a3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a905b01b-beaf-4e5b-8998-2e9626a91cc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""bb9e63b5-cd3c-4cc3-a030-dbab584ab4c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""55f0d6c8-7967-4138-8f3e-ed8a8cd5b33d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""5b76a826-b6a9-4845-8f60-3aa2a7744cab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""cbd23e76-1da0-473e-b077-dfd8ff785af9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowMo"",
                    ""type"": ""Button"",
                    ""id"": ""35a4e5b7-753d-4823-9668-9a035b72aa35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprite"",
                    ""type"": ""Button"",
                    ""id"": ""fc685147-d365-41e6-bc8b-c8c18c87d5ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pistol"",
                    ""type"": ""Button"",
                    ""id"": ""ad96833f-61cc-49e0-a623-a0a3d4b74a4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shotgun"",
                    ""type"": ""Button"",
                    ""id"": ""e850007a-88d8-4a2f-a95a-49ef51fc7f32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Assult Rifle"",
                    ""type"": ""Button"",
                    ""id"": ""e2ac364f-dbd3-4aeb-83d4-03f5d7438fb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grenade"",
                    ""type"": ""Button"",
                    ""id"": ""0e501da7-984c-4cac-a903-be3f1fb220f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3da7fd83-5363-4e3d-82a1-f070f262c9ff"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bbf3784-38f1-426a-802a-950639aff762"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ef6797d-77ab-4314-8f6e-9f7cdae50162"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe652441-dfd6-4643-ab13-4d36c627dd51"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427c8fc2-93ce-4d81-98fb-834b6815af80"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50e8cb38-b37c-4e03-9c10-3e90e62e55d3"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10e67dbf-9e52-49fb-8c9d-3d52aa2fbd1c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e38d1635-ff43-4122-aef5-70cfa5bc0e1f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bb9fb72-9bbe-4d4f-8a51-a5011fe892af"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""175168ea-3aa3-43dd-862d-b00ec81d20d8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowMo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b8f09cc-6a96-45d7-a240-a53719cfa0c8"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f3e3c96-2594-4772-a7de-9a0c7533664a"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pistol"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f434fa2-c2aa-4388-bac2-315e8d0152d7"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c5bd769-4d3a-424e-b1c3-e2d0693bfa68"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Assult Rifle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a1716e5-b229-4fff-852d-cd8dc7235f75"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grenade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Forward = m_Player.FindAction("Forward", throwIfNotFound: true);
        m_Player_Back = m_Player.FindAction("Back", throwIfNotFound: true);
        m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
        m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Secondary = m_Player.FindAction("Secondary", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_SlowMo = m_Player.FindAction("SlowMo", throwIfNotFound: true);
        m_Player_Sprite = m_Player.FindAction("Sprite", throwIfNotFound: true);
        m_Player_Pistol = m_Player.FindAction("Pistol", throwIfNotFound: true);
        m_Player_Shotgun = m_Player.FindAction("Shotgun", throwIfNotFound: true);
        m_Player_AssultRifle = m_Player.FindAction("Assult Rifle", throwIfNotFound: true);
        m_Player_Grenade = m_Player.FindAction("Grenade", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Forward;
    private readonly InputAction m_Player_Back;
    private readonly InputAction m_Player_Left;
    private readonly InputAction m_Player_Right;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Secondary;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_SlowMo;
    private readonly InputAction m_Player_Sprite;
    private readonly InputAction m_Player_Pistol;
    private readonly InputAction m_Player_Shotgun;
    private readonly InputAction m_Player_AssultRifle;
    private readonly InputAction m_Player_Grenade;
    public struct PlayerActions
    {
        private @_Input m_Wrapper;
        public PlayerActions(@_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Player_Forward;
        public InputAction @Back => m_Wrapper.m_Player_Back;
        public InputAction @Left => m_Wrapper.m_Player_Left;
        public InputAction @Right => m_Wrapper.m_Player_Right;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Secondary => m_Wrapper.m_Player_Secondary;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @SlowMo => m_Wrapper.m_Player_SlowMo;
        public InputAction @Sprite => m_Wrapper.m_Player_Sprite;
        public InputAction @Pistol => m_Wrapper.m_Player_Pistol;
        public InputAction @Shotgun => m_Wrapper.m_Player_Shotgun;
        public InputAction @AssultRifle => m_Wrapper.m_Player_AssultRifle;
        public InputAction @Grenade => m_Wrapper.m_Player_Grenade;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Back.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBack;
                @Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Secondary.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondary;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @SlowMo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowMo;
                @SlowMo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowMo;
                @SlowMo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowMo;
                @Sprite.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprite;
                @Sprite.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprite;
                @Sprite.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprite;
                @Pistol.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPistol;
                @Pistol.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPistol;
                @Pistol.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPistol;
                @Shotgun.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShotgun;
                @Shotgun.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShotgun;
                @Shotgun.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShotgun;
                @AssultRifle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAssultRifle;
                @AssultRifle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAssultRifle;
                @AssultRifle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAssultRifle;
                @Grenade.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrenade;
                @Grenade.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrenade;
                @Grenade.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrenade;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @SlowMo.started += instance.OnSlowMo;
                @SlowMo.performed += instance.OnSlowMo;
                @SlowMo.canceled += instance.OnSlowMo;
                @Sprite.started += instance.OnSprite;
                @Sprite.performed += instance.OnSprite;
                @Sprite.canceled += instance.OnSprite;
                @Pistol.started += instance.OnPistol;
                @Pistol.performed += instance.OnPistol;
                @Pistol.canceled += instance.OnPistol;
                @Shotgun.started += instance.OnShotgun;
                @Shotgun.performed += instance.OnShotgun;
                @Shotgun.canceled += instance.OnShotgun;
                @AssultRifle.started += instance.OnAssultRifle;
                @AssultRifle.performed += instance.OnAssultRifle;
                @AssultRifle.canceled += instance.OnAssultRifle;
                @Grenade.started += instance.OnGrenade;
                @Grenade.performed += instance.OnGrenade;
                @Grenade.canceled += instance.OnGrenade;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSlowMo(InputAction.CallbackContext context);
        void OnSprite(InputAction.CallbackContext context);
        void OnPistol(InputAction.CallbackContext context);
        void OnShotgun(InputAction.CallbackContext context);
        void OnAssultRifle(InputAction.CallbackContext context);
        void OnGrenade(InputAction.CallbackContext context);
    }
}
