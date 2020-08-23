// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input.inputactions'

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
                    ""name"": ""ChopTree"",
                    ""type"": ""Button"",
                    ""id"": ""1f9d3701-03a9-4e4f-aa51-0e4940d17f8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WaterPlant"",
                    ""type"": ""Button"",
                    ""id"": ""22e89871-6a0b-4394-8485-cf1f88621fc9"",
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
                    ""name"": ""PlantSeed"",
                    ""type"": ""Button"",
                    ""id"": ""abfc48b4-3de2-4ebc-ac1d-978272ed3f12"",
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
                    ""id"": ""1b6a4b90-8669-431f-b8ae-e573ed7c189f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChopTree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a205f920-1ec5-4725-92fa-d5995b02e518"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WaterPlant"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ffbd22a-de76-4bc6-87a4-402c6d8ccd90"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sapling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""058519f5-34dc-4bee-95c7-b19245288fff"",
                    ""path"": ""<Keyboard>/2"",
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
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CottonSeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f269742-ec57-4a28-ace8-70f70fb861d0"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlantSeed"",
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
        m_player_ChopTree = m_player.FindAction("ChopTree", throwIfNotFound: true);
        m_player_WaterPlant = m_player.FindAction("WaterPlant", throwIfNotFound: true);
        m_player_Sapling = m_player.FindAction("Sapling", throwIfNotFound: true);
        m_player_AloeSeed = m_player.FindAction("AloeSeed", throwIfNotFound: true);
        m_player_CottonSeed = m_player.FindAction("CottonSeed", throwIfNotFound: true);
        m_player_PlantSeed = m_player.FindAction("PlantSeed", throwIfNotFound: true);
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
    private readonly InputAction m_player_ChopTree;
    private readonly InputAction m_player_WaterPlant;
    private readonly InputAction m_player_Sapling;
    private readonly InputAction m_player_AloeSeed;
    private readonly InputAction m_player_CottonSeed;
    private readonly InputAction m_player_PlantSeed;
    public struct PlayerActions
    {
        private @PlayerAction m_Wrapper;
        public PlayerActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_player_movement;
        public InputAction @LadderMovement => m_Wrapper.m_player_LadderMovement;
        public InputAction @ChopTree => m_Wrapper.m_player_ChopTree;
        public InputAction @WaterPlant => m_Wrapper.m_player_WaterPlant;
        public InputAction @Sapling => m_Wrapper.m_player_Sapling;
        public InputAction @AloeSeed => m_Wrapper.m_player_AloeSeed;
        public InputAction @CottonSeed => m_Wrapper.m_player_CottonSeed;
        public InputAction @PlantSeed => m_Wrapper.m_player_PlantSeed;
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
                @ChopTree.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChopTree;
                @ChopTree.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChopTree;
                @ChopTree.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChopTree;
                @WaterPlant.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWaterPlant;
                @WaterPlant.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWaterPlant;
                @WaterPlant.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWaterPlant;
                @Sapling.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSapling;
                @Sapling.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSapling;
                @Sapling.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSapling;
                @AloeSeed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAloeSeed;
                @AloeSeed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAloeSeed;
                @AloeSeed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAloeSeed;
                @CottonSeed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCottonSeed;
                @CottonSeed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCottonSeed;
                @CottonSeed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCottonSeed;
                @PlantSeed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlantSeed;
                @PlantSeed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlantSeed;
                @PlantSeed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlantSeed;
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
                @ChopTree.started += instance.OnChopTree;
                @ChopTree.performed += instance.OnChopTree;
                @ChopTree.canceled += instance.OnChopTree;
                @WaterPlant.started += instance.OnWaterPlant;
                @WaterPlant.performed += instance.OnWaterPlant;
                @WaterPlant.canceled += instance.OnWaterPlant;
                @Sapling.started += instance.OnSapling;
                @Sapling.performed += instance.OnSapling;
                @Sapling.canceled += instance.OnSapling;
                @AloeSeed.started += instance.OnAloeSeed;
                @AloeSeed.performed += instance.OnAloeSeed;
                @AloeSeed.canceled += instance.OnAloeSeed;
                @CottonSeed.started += instance.OnCottonSeed;
                @CottonSeed.performed += instance.OnCottonSeed;
                @CottonSeed.canceled += instance.OnCottonSeed;
                @PlantSeed.started += instance.OnPlantSeed;
                @PlantSeed.performed += instance.OnPlantSeed;
                @PlantSeed.canceled += instance.OnPlantSeed;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLadderMovement(InputAction.CallbackContext context);
        void OnChopTree(InputAction.CallbackContext context);
        void OnWaterPlant(InputAction.CallbackContext context);
        void OnSapling(InputAction.CallbackContext context);
        void OnAloeSeed(InputAction.CallbackContext context);
        void OnCottonSeed(InputAction.CallbackContext context);
        void OnPlantSeed(InputAction.CallbackContext context);
    }
}
