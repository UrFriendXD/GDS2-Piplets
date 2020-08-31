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
                    ""name"": ""AloeSeed"",
                    ""type"": ""Button"",
                    ""id"": ""8bff560a-d451-479f-b59c-d98e34f39bc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CottonSeed"",
                    ""type"": ""Button"",
                    ""id"": ""8acdf920-52b3-43de-8646-c5d38dbefa84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sapling"",
                    ""type"": ""Button"",
                    ""id"": ""db1eb91f-fe6e-426f-bd77-6d1145856e17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Watering Can"",
                    ""type"": ""Button"",
                    ""id"": ""de150bb8-6d0e-4fae-a551-e9dda4a745b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Axe"",
                    ""type"": ""Button"",
                    ""id"": ""040b422d-73f7-4098-b9f2-7ac096582851"",
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
                    ""action"": ""AloeSeed"",
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
                    ""action"": ""CottonSeed"",
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
                    ""action"": ""Sapling"",
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
                    ""action"": ""Select Watering Can"",
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
                    ""action"": ""Select Axe"",
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
        m_player_AloeSeed = m_player.FindAction("AloeSeed", throwIfNotFound: true);
        m_player_CottonSeed = m_player.FindAction("CottonSeed", throwIfNotFound: true);
        m_player_Sapling = m_player.FindAction("Sapling", throwIfNotFound: true);
        m_player_SelectWateringCan = m_player.FindAction("Select Watering Can", throwIfNotFound: true);
        m_player_SelectAxe = m_player.FindAction("Select Axe", throwIfNotFound: true);
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
    private readonly InputAction m_player_AloeSeed;
    private readonly InputAction m_player_CottonSeed;
    private readonly InputAction m_player_Sapling;
    private readonly InputAction m_player_SelectWateringCan;
    private readonly InputAction m_player_SelectAxe;
    public struct PlayerActions
    {
        private @PlayerAction m_Wrapper;
        public PlayerActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_player_movement;
        public InputAction @LadderMovement => m_Wrapper.m_player_LadderMovement;
        public InputAction @InteractBare => m_Wrapper.m_player_InteractBare;
        public InputAction @Action => m_Wrapper.m_player_Action;
        public InputAction @AloeSeed => m_Wrapper.m_player_AloeSeed;
        public InputAction @CottonSeed => m_Wrapper.m_player_CottonSeed;
        public InputAction @Sapling => m_Wrapper.m_player_Sapling;
        public InputAction @SelectWateringCan => m_Wrapper.m_player_SelectWateringCan;
        public InputAction @SelectAxe => m_Wrapper.m_player_SelectAxe;
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
                @AloeSeed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAloeSeed;
                @AloeSeed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAloeSeed;
                @AloeSeed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAloeSeed;
                @CottonSeed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCottonSeed;
                @CottonSeed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCottonSeed;
                @CottonSeed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCottonSeed;
                @Sapling.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSapling;
                @Sapling.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSapling;
                @Sapling.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSapling;
                @SelectWateringCan.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWateringCan;
                @SelectWateringCan.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWateringCan;
                @SelectWateringCan.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWateringCan;
                @SelectAxe.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectAxe;
                @SelectAxe.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectAxe;
                @SelectAxe.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectAxe;
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
                @AloeSeed.started += instance.OnAloeSeed;
                @AloeSeed.performed += instance.OnAloeSeed;
                @AloeSeed.canceled += instance.OnAloeSeed;
                @CottonSeed.started += instance.OnCottonSeed;
                @CottonSeed.performed += instance.OnCottonSeed;
                @CottonSeed.canceled += instance.OnCottonSeed;
                @Sapling.started += instance.OnSapling;
                @Sapling.performed += instance.OnSapling;
                @Sapling.canceled += instance.OnSapling;
                @SelectWateringCan.started += instance.OnSelectWateringCan;
                @SelectWateringCan.performed += instance.OnSelectWateringCan;
                @SelectWateringCan.canceled += instance.OnSelectWateringCan;
                @SelectAxe.started += instance.OnSelectAxe;
                @SelectAxe.performed += instance.OnSelectAxe;
                @SelectAxe.canceled += instance.OnSelectAxe;
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
        void OnAloeSeed(InputAction.CallbackContext context);
        void OnCottonSeed(InputAction.CallbackContext context);
        void OnSapling(InputAction.CallbackContext context);
        void OnSelectWateringCan(InputAction.CallbackContext context);
        void OnSelectAxe(InputAction.CallbackContext context);
    }
}
