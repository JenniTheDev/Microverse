// GENERATED AUTOMATICALLY FROM 'Assets/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""JenniSays"",
            ""id"": ""efd77b36-e474-4ea7-b9e7-64f6ad2b6b7f"",
            ""actions"": [
                {
                    ""name"": ""RegularInput"",
                    ""type"": ""Button"",
                    ""id"": ""c5ab968b-d0c4-483c-903b-0f70d7d4e211"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ButtonPassThrough"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e447afbb-6db7-470e-945d-38453f3f93f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2418a403-c9d9-4e75-87b8-0064cb53c818"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RegularInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c82f0d99-ef58-4edc-86cf-4031d87407c0"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonPassThrough"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // JenniSays
        m_JenniSays = asset.FindActionMap("JenniSays", throwIfNotFound: true);
        m_JenniSays_RegularInput = m_JenniSays.FindAction("RegularInput", throwIfNotFound: true);
        m_JenniSays_ButtonPassThrough = m_JenniSays.FindAction("ButtonPassThrough", throwIfNotFound: true);
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

    // JenniSays
    private readonly InputActionMap m_JenniSays;
    private IJenniSaysActions m_JenniSaysActionsCallbackInterface;
    private readonly InputAction m_JenniSays_RegularInput;
    private readonly InputAction m_JenniSays_ButtonPassThrough;
    public struct JenniSaysActions
    {
        private @Input m_Wrapper;
        public JenniSaysActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @RegularInput => m_Wrapper.m_JenniSays_RegularInput;
        public InputAction @ButtonPassThrough => m_Wrapper.m_JenniSays_ButtonPassThrough;
        public InputActionMap Get() { return m_Wrapper.m_JenniSays; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JenniSaysActions set) { return set.Get(); }
        public void SetCallbacks(IJenniSaysActions instance)
        {
            if (m_Wrapper.m_JenniSaysActionsCallbackInterface != null)
            {
                @RegularInput.started -= m_Wrapper.m_JenniSaysActionsCallbackInterface.OnRegularInput;
                @RegularInput.performed -= m_Wrapper.m_JenniSaysActionsCallbackInterface.OnRegularInput;
                @RegularInput.canceled -= m_Wrapper.m_JenniSaysActionsCallbackInterface.OnRegularInput;
                @ButtonPassThrough.started -= m_Wrapper.m_JenniSaysActionsCallbackInterface.OnButtonPassThrough;
                @ButtonPassThrough.performed -= m_Wrapper.m_JenniSaysActionsCallbackInterface.OnButtonPassThrough;
                @ButtonPassThrough.canceled -= m_Wrapper.m_JenniSaysActionsCallbackInterface.OnButtonPassThrough;
            }
            m_Wrapper.m_JenniSaysActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RegularInput.started += instance.OnRegularInput;
                @RegularInput.performed += instance.OnRegularInput;
                @RegularInput.canceled += instance.OnRegularInput;
                @ButtonPassThrough.started += instance.OnButtonPassThrough;
                @ButtonPassThrough.performed += instance.OnButtonPassThrough;
                @ButtonPassThrough.canceled += instance.OnButtonPassThrough;
            }
        }
    }
    public JenniSaysActions @JenniSays => new JenniSaysActions(this);
    public interface IJenniSaysActions
    {
        void OnRegularInput(InputAction.CallbackContext context);
        void OnButtonPassThrough(InputAction.CallbackContext context);
    }
}
