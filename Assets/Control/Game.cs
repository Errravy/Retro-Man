//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Control/Game.inputactions
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

public partial class @PlayerControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Game"",
    ""maps"": [
        {
            ""name"": ""Run"",
            ""id"": ""8560035a-4775-45ce-be73-71d862a0ec51"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d27abaf0-a648-4398-9064-7b611d5c53a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69c51b36-be3e-4a5b-9e34-44fcc6828e00"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Fly"",
            ""id"": ""56efbf53-5871-4380-a6e6-6e68456579eb"",
            ""actions"": [
                {
                    ""name"": ""Gravity"",
                    ""type"": ""Button"",
                    ""id"": ""509c240c-da8b-42f6-bb87-a532a280d0f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""590680a2-9b1a-4b93-ad1b-fce672ff0e80"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gravity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Wall"",
            ""id"": ""d1bb770f-fb48-4378-82e5-425e1e3438d4"",
            ""actions"": [
                {
                    ""name"": ""Side"",
                    ""type"": ""Button"",
                    ""id"": ""82d4a86a-8146-4437-a9de-6a8fc00abf3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d036bc3-e6ba-4bdb-97ea-d42b87066a7d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Side"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Run
        m_Run = asset.FindActionMap("Run", throwIfNotFound: true);
        m_Run_Jump = m_Run.FindAction("Jump", throwIfNotFound: true);
        // Fly
        m_Fly = asset.FindActionMap("Fly", throwIfNotFound: true);
        m_Fly_Gravity = m_Fly.FindAction("Gravity", throwIfNotFound: true);
        // Wall
        m_Wall = asset.FindActionMap("Wall", throwIfNotFound: true);
        m_Wall_Side = m_Wall.FindAction("Side", throwIfNotFound: true);
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

    // Run
    private readonly InputActionMap m_Run;
    private IRunActions m_RunActionsCallbackInterface;
    private readonly InputAction m_Run_Jump;
    public struct RunActions
    {
        private @PlayerControl m_Wrapper;
        public RunActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Run_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Run; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RunActions set) { return set.Get(); }
        public void SetCallbacks(IRunActions instance)
        {
            if (m_Wrapper.m_RunActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_RunActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_RunActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_RunActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_RunActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public RunActions @Run => new RunActions(this);

    // Fly
    private readonly InputActionMap m_Fly;
    private IFlyActions m_FlyActionsCallbackInterface;
    private readonly InputAction m_Fly_Gravity;
    public struct FlyActions
    {
        private @PlayerControl m_Wrapper;
        public FlyActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Gravity => m_Wrapper.m_Fly_Gravity;
        public InputActionMap Get() { return m_Wrapper.m_Fly; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlyActions set) { return set.Get(); }
        public void SetCallbacks(IFlyActions instance)
        {
            if (m_Wrapper.m_FlyActionsCallbackInterface != null)
            {
                @Gravity.started -= m_Wrapper.m_FlyActionsCallbackInterface.OnGravity;
                @Gravity.performed -= m_Wrapper.m_FlyActionsCallbackInterface.OnGravity;
                @Gravity.canceled -= m_Wrapper.m_FlyActionsCallbackInterface.OnGravity;
            }
            m_Wrapper.m_FlyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Gravity.started += instance.OnGravity;
                @Gravity.performed += instance.OnGravity;
                @Gravity.canceled += instance.OnGravity;
            }
        }
    }
    public FlyActions @Fly => new FlyActions(this);

    // Wall
    private readonly InputActionMap m_Wall;
    private IWallActions m_WallActionsCallbackInterface;
    private readonly InputAction m_Wall_Side;
    public struct WallActions
    {
        private @PlayerControl m_Wrapper;
        public WallActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Side => m_Wrapper.m_Wall_Side;
        public InputActionMap Get() { return m_Wrapper.m_Wall; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WallActions set) { return set.Get(); }
        public void SetCallbacks(IWallActions instance)
        {
            if (m_Wrapper.m_WallActionsCallbackInterface != null)
            {
                @Side.started -= m_Wrapper.m_WallActionsCallbackInterface.OnSide;
                @Side.performed -= m_Wrapper.m_WallActionsCallbackInterface.OnSide;
                @Side.canceled -= m_Wrapper.m_WallActionsCallbackInterface.OnSide;
            }
            m_Wrapper.m_WallActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Side.started += instance.OnSide;
                @Side.performed += instance.OnSide;
                @Side.canceled += instance.OnSide;
            }
        }
    }
    public WallActions @Wall => new WallActions(this);
    public interface IRunActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IFlyActions
    {
        void OnGravity(InputAction.CallbackContext context);
    }
    public interface IWallActions
    {
        void OnSide(InputAction.CallbackContext context);
    }
}
