using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine.Windows;
using static UnityEditor.PlayerSettings;

public class InputManager : MonoBehaviour
{
    public static Input _input { private set; get; }
    public static InputManager Instance;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] InputSO _inputSO;
    void Awake()
    {
        if (Instance == null)
        {
            _input = new Input();
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        EnableGameInput();
    }
    private void OnDisable()
    {
        DisableGameInput();
    }
    void EnableGameInput()
    {
        _input.InGame.Enable();

        _input.InGame.Look.performed += context => _inputSO.OnLook(_input.InGame.Look.ReadValue<Vector2>());
        _input.InGame.Look.canceled += context => _inputSO.OnLook(Vector2.zero);
        _input.InGame.LookGamepad.performed += context => _inputSO.OnLookGamePad(_input.InGame.LookGamepad.ReadValue<Vector2>());
        _input.InGame.LookGamepad.canceled += context => _inputSO.OnLookGamePad(Vector2.zero);
        _input.InGame.Move.performed += context => _inputSO.OnMove(_input.InGame.Move.ReadValue<Vector2>());
        _input.InGame.Move.canceled += context => _inputSO.OnMove(Vector2.zero);
        _input.InGame.Shoot.performed += context => _inputSO.OnShoot(true);
        _input.InGame.Shoot.canceled += context => _inputSO.OnShoot(false);
        _input.InGame.OpenInventory.performed += context => _inputSO.OnInventory(true);
        _input.InGame.OpenInventory.canceled += context => _inputSO.OnInventory(false);
    }

    void DisableGameInput()
    {
        _input.InGame.Move.performed -= context => _inputSO.OnMove(_input.InGame.Move.ReadValue<Vector2>());
        _input.InGame.Look.performed -= context => _inputSO.OnLook(_input.InGame.Look.ReadValue<Vector2>());
        _input.InGame.LookGamepad.performed -= context => _inputSO.OnLookGamePad(_input.InGame.LookGamepad.ReadValue<Vector2>());
        _input.InGame.Move.canceled -= context => _inputSO.OnMove(Vector2.zero);
        _input.InGame.Look.canceled -= context => _inputSO.OnLook(Vector2.zero);
        _input.InGame.LookGamepad.canceled -= context => _inputSO.OnLookGamePad(Vector2.zero);
        _input.InGame.Shoot.performed -= context => _inputSO.OnShoot(true);
        _input.InGame.Shoot.canceled -= context => _inputSO.OnShoot(false);
        _input.InGame.OpenInventory.performed -= context => _inputSO.OnInventory(true);
        _input.InGame.OpenInventory.canceled -= context => _inputSO.OnInventory(false);
        _input.InGame.Disable();
    }
    private void Update()
    {
        InputDevice lastUsedDevice = null;
        float lastEventTime = 0;
        foreach (var device in InputSystem.devices)
        {
            if (device.lastUpdateTime > lastEventTime)
            {
                lastUsedDevice = device;
                lastEventTime = (float)device.lastUpdateTime;
            }
        }

        if (lastUsedDevice is Gamepad)
        {
            _inputSO._isInputManette = true;
        }
        else
        {
            _inputSO._isInputManette = false;
        }
    }
}
