using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputMode : MonoBehaviour
{
    public event Action<InputModeType, InputModeType> OnDeviceChanged;
    public InputModeType CurrentDevice;


    void Update()
    {
        // Check mouse input
        if (Mouse.current != null &&
            (Mouse.current.delta.ReadValue() != Vector2.zero || Mouse.current.leftButton.wasPressedThisFrame))
        {
            UpdateDevice("Mouse");
        }
        // Check for keyboard input
        else if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            UpdateDevice("Keyboard");
        }
        // Check for gamepad input
        else if (Gamepad.current != null && AnyGamepadButtonPressed(Gamepad.current))
        {
            UpdateDevice("Controller");
        }
    }

    void UpdateDevice(string deviceName)
    {
        
        if (CurrentDevice.ToString() != deviceName)
        {
            OnDeviceChanged?.Invoke(CurrentDevice, (InputModeType)Enum.Parse(typeof(InputModeType), deviceName));
            CurrentDevice = (InputModeType)Enum.Parse(typeof(InputModeType), deviceName);
        }
    }

    bool AnyGamepadButtonPressed(Gamepad pad)
    {
        foreach (var control in pad.allControls)
        {
            if (control is ButtonControl button && button.wasPressedThisFrame)
                return true;
        }
        return false;
    }
}

public enum InputModeType
{
    Mouse,
    Keyboard,
    Controller
}