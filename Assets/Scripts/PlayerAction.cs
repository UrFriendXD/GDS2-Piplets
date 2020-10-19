// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""5dcf7681-abcb-41ba-95b6-628865a14db0"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c6adbdbd-538d-4e7e-b8f4-92b6ffb1c4a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LadderMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4938417d-d387-4dd5-a10b-a7f0f2f8c45f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractBare"",
                    ""type"": ""Button"",
                    ""id"": ""57e26702-95cd-4f5e-9ad7-0c3374691c72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""1f9d3701-03a9-4e4f-aa51-0e4940d17f8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zero"",
                    ""type"": ""Button"",
                    ""id"": ""8bff560a-d451-479f-b59c-d98e34f39bc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""One"",
                    ""type"": ""Button"",
                    ""id"": ""8acdf920-52b3-43de-8646-c5d38dbefa84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Two"",
                    ""type"": ""Button"",
                    ""id"": ""db1eb91f-fe6e-426f-bd77-6d1145856e17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Three"",
                    ""type"": ""Button"",
                    ""id"": ""de150bb8-6d0e-4fae-a551-e9dda4a745b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Four"",
                    ""type"": ""Button"",
                    ""id"": ""040b422d-73f7-4098-b9f2-7ac096582851"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""cf706427-f80a-4c7c-955d-6b66a492f875"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""08ad964b-3b1c-49c4-b1f3-712355ba0555"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Five"",
                    ""type"": ""Button"",
                    ""id"": ""d8bab1b3-2d91-483c-b5d3-c5ad3d481d54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Six"",
                    ""type"": ""Button"",
                    ""id"": ""410600ab-17ba-4c79-8d12-04cb0cba2040"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Seven"",
                    ""type"": ""Button"",
                    ""id"": ""0c3d9c21-8e55-445b-bcfd-e7b6a6a8cf38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Eight"",
                    ""type"": ""Button"",
                    ""id"": ""e3f30d33-60b2-415a-b957-112bd3d0fc92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Nine"",
                    ""type"": ""Button"",
                    ""id"": ""630c2a3d-ceea-4c02-b335-a1407a52d16a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ten"",
                    ""type"": ""Button"",
                    ""id"": ""272c0abe-fa86-4b73-87cc-ef60eb436ea6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Eleven"",
                    ""type"": ""Button"",
                    ""id"": ""23a70487-7842-4db8-aa0b-35cfe4551027"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Sideways"",
                    ""id"": ""0f095be0-9ffd-4b1d-9d6b-983ce7a320d9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8c3b6324-c6a0-45e9-8447-724fd4a5bc62"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a590c0ff-db14-46c5-952d-6f9ce196fdcc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""UpandDown"",
                    ""id"": ""eebd4e19-e9ce-42f5-9ece-772d0e8c961b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LadderMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b976ba8b-bb87-44d3-b922-ca80ada8da7d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LadderMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""de8dff66-da8b-42a1-a836-be5d31b77671"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LadderMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""058519f5-34dc-4bee-95c7-b19245288fff"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zero"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8619f5e-0954-4a66-85a3-90573ee6e116"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""One"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ffbd22a-de76-4bc6-87a4-402c6d8ccd90"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Two"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b48c420b-ed03-4590-a4ea-19a402e4e4b5"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Three"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""572b728a-49aa-4901-8dbe-6ca6d0933e11"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractBare"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b6a4b90-8669-431f-b8ae-e573ed7c189f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c133d520-d063-4bf1-a34e-0d0d21fb8657"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Four"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8a86a02-feff-47d0-a69d-e0be277abba5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""052bc2e0-b1b5-4771-9ca1-b77c5734c329"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38b395be-e258-4c1d-bfdc-aaad0cd066d6"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Five"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcdda311-c025-4b69-8a1b-99e7e77c9f0c"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Six"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acceb690-f1f0-4e75-b61d-bdc09be665f3"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Seven"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1874b1f8-17f2-4bf4-9ef1-4c2c1682e184"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Eight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b439cd9-d2b1-415f-aaa8-463bc69392f8"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Nine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""225c3e35-736c-4f8a-98ad-93b0b26199d6"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ten"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21278050-da9e-4159-b5f8-e9b21a1794c8"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Eleven"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_movement = m_player.FindAction("movement", throwIfNotFound: true);
        m_player_LadderMovement = m_player.FindAction("LadderMovement", throwIfNotFound: true);
        m_player_InteractBare = m_player.FindAction("InteractBare", throwIfNotFound: true);
        m_player_Action = m_player.FindAction("Action", throwIfNotFound: true);
        m_player_Zero = m_player.FindAction("Zero", throwIfNotFound: true);
        m_player_One = m_player.FindAction("One", throwIfNotFound: true);
        m_player_Two = m_player.FindAction("Two", throwIfNotFound: true);
        m_player_Three = m_player.FindAction("Three", throwIfNotFound: true);
        m_player_Four = m_player.FindAction("Four", throwIfNotFound: true);
        m_player_Cancel = m_player.FindAction("Cancel", throwIfNotFound: true);
        m_player_Menu = m_player.FindAction("Menu", throwIfNotFound: true);
        m_player_Five = m_player.FindAction("Five", throwIfNotFound: true);
        m_player_Six = m_player.FindAction("Six", throwIfNotFound: true);
        m_player_Seven = m_player.FindAction("Seven", throwIfNotFound: true);
        m_player_Eight = m_player.FindAction("Eight", throwIfNotFound: true);
        m_player_Nine = m_player.FindAction("Nine", throwIfNotFound: true);
        m_player_Ten = m_player.FindAction("Ten", throwIfNotFound: true);
        m_player_Eleven = m_player.FindAction("Eleven", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_player_movement;
    private readonly InputAction m_player_LadderMovement;
    private readonly InputAction m_player_InteractBare;
    private readonly InputAction m_player_Action;
    private readonly InputAction m_player_Zero;
    private readonly InputAction m_player_One;
    private readonly InputAction m_player_Two;
    private readonly InputAction m_player_Three;
    private readonly InputAction m_player_Four;
    private readonly InputAction m_player_Cancel;
    private readonly InputAction m_player_Menu;
    private readonly InputAction m_player_Five;
    private readonly InputAction m_player_Six;
    private readonly InputAction m_player_Seven;
    private readonly InputAction m_player_Eight;
    private readonly InputAction m_player_Nine;
    private readonly InputAction m_player_Ten;
    private readonly InputAction m_player_Eleven;
    public struct PlayerActions
    {
        private @PlayerAction m_Wrapper;
        public PlayerActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_player_movement;
        public InputAction @LadderMovement => m_Wrapper.m_player_LadderMovement;
        public InputAction @InteractBare => m_Wrapper.m_player_InteractBare;
        public InputAction @Action => m_Wrapper.m_player_Action;
        public InputAction @Zero => m_Wrapper.m_player_Zero;
        public InputAction @One => m_Wrapper.m_player_One;
        public InputAction @Two => m_Wrapper.m_player_Two;
        public InputAction @Three => m_Wrapper.m_player_Three;
        public InputAction @Four => m_Wrapper.m_player_Four;
        public InputAction @Cancel => m_Wrapper.m_player_Cancel;
        public InputAction @Menu => m_Wrapper.m_player_Menu;
        public InputAction @Five => m_Wrapper.m_player_Five;
        public InputAction @Six => m_Wrapper.m_player_Six;
        public InputAction @Seven => m_Wrapper.m_player_Seven;
        public InputAction @Eight => m_Wrapper.m_player_Eight;
        public InputAction @Nine => m_Wrapper.m_player_Nine;
        public InputAction @Ten => m_Wrapper.m_player_Ten;
        public InputAction @Eleven => m_Wrapper.m_player_Eleven;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @LadderMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLadderMovement;
                @LadderMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLadderMovement;
                @LadderMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLadderMovement;
                @InteractBare.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractBare;
                @InteractBare.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractBare;
                @InteractBare.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractBare;
                @Action.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                @Zero.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZero;
                @Zero.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZero;
                @Zero.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZero;
                @One.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOne;
                @One.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOne;
                @One.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOne;
                @Two.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwo;
                @Two.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwo;
                @Two.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTwo;
                @Three.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThree;
                @Three.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThree;
                @Three.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThree;
                @Four.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFour;
                @Four.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFour;
                @Four.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFour;
                @Cancel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancel;
                @Menu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                @Five.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFive;
                @Five.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFive;
                @Five.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFive;
                @Six.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSix;
                @Six.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSix;
                @Six.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSix;
                @Seven.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSeven;
                @Seven.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSeven;
                @Seven.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSeven;
                @Eight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEight;
                @Eight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEight;
                @Eight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEight;
                @Nine.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNine;
                @Nine.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNine;
                @Nine.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNine;
                @Ten.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTen;
                @Ten.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTen;
                @Ten.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTen;
                @Eleven.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleven;
                @Eleven.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleven;
                @Eleven.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEleven;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @LadderMovement.started += instance.OnLadderMovement;
                @LadderMovement.performed += instance.OnLadderMovement;
                @LadderMovement.canceled += instance.OnLadderMovement;
                @InteractBare.started += instance.OnInteractBare;
                @InteractBare.performed += instance.OnInteractBare;
                @InteractBare.canceled += instance.OnInteractBare;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Zero.started += instance.OnZero;
                @Zero.performed += instance.OnZero;
                @Zero.canceled += instance.OnZero;
                @One.started += instance.OnOne;
                @One.performed += instance.OnOne;
                @One.canceled += instance.OnOne;
                @Two.started += instance.OnTwo;
                @Two.performed += instance.OnTwo;
                @Two.canceled += instance.OnTwo;
                @Three.started += instance.OnThree;
                @Three.performed += instance.OnThree;
                @Three.canceled += instance.OnThree;
                @Four.started += instance.OnFour;
                @Four.performed += instance.OnFour;
                @Four.canceled += instance.OnFour;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Five.started += instance.OnFive;
                @Five.performed += instance.OnFive;
                @Five.canceled += instance.OnFive;
                @Six.started += instance.OnSix;
                @Six.performed += instance.OnSix;
                @Six.canceled += instance.OnSix;
                @Seven.started += instance.OnSeven;
                @Seven.performed += instance.OnSeven;
                @Seven.canceled += instance.OnSeven;
                @Eight.started += instance.OnEight;
                @Eight.performed += instance.OnEight;
                @Eight.canceled += instance.OnEight;
                @Nine.started += instance.OnNine;
                @Nine.performed += instance.OnNine;
                @Nine.canceled += instance.OnNine;
                @Ten.started += instance.OnTen;
                @Ten.performed += instance.OnTen;
                @Ten.canceled += instance.OnTen;
                @Eleven.started += instance.OnEleven;
                @Eleven.performed += instance.OnEleven;
                @Eleven.canceled += instance.OnEleven;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLadderMovement(InputAction.CallbackContext context);
        void OnInteractBare(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnZero(InputAction.CallbackContext context);
        void OnOne(InputAction.CallbackContext context);
        void OnTwo(InputAction.CallbackContext context);
        void OnThree(InputAction.CallbackContext context);
        void OnFour(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnFive(InputAction.CallbackContext context);
        void OnSix(InputAction.CallbackContext context);
        void OnSeven(InputAction.CallbackContext context);
        void OnEight(InputAction.CallbackContext context);
        void OnNine(InputAction.CallbackContext context);
        void OnTen(InputAction.CallbackContext context);
        void OnEleven(InputAction.CallbackContext context);
    }
}
