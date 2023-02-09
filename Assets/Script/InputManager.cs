using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Input _input { private set; get; }
    [SerializeField] PlayerInput playerInput;
    [SerializeField] InputSO _inputSO;
    void Awake()
    {
        _input = new Input();
    }
    private void OnEnable()
    {
        EnableGameInput();
    }
    private void OnDisable()
    {
        DisableGameInput();
    }
    public void EnableGameInput()
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

        _input.InGame.SelectWeapon.performed += context => _inputSO.OnSelectWeapon(_input.InGame.SelectWeapon.ReadValue<Vector2>());
        _input.InGame.SelectWeapon.canceled += context => _inputSO.OnSelectWeapon(Vector2.zero);
    }

    void DisableGameInput()
    {
        _input.InGame.Move.performed -= context => _inputSO.OnMove(_input.InGame.Move.ReadValue<Vector2>());
        _input.InGame.Move.canceled -= context => _inputSO.OnMove(Vector2.zero);

        _input.InGame.Look.performed -= context => _inputSO.OnLook(_input.InGame.Look.ReadValue<Vector2>());
        _input.InGame.Look.canceled -= context => _inputSO.OnLook(Vector2.zero);

        _input.InGame.LookGamepad.performed -= context => _inputSO.OnLookGamePad(_input.InGame.LookGamepad.ReadValue<Vector2>());
        _input.InGame.LookGamepad.canceled -= context => _inputSO.OnLookGamePad(Vector2.zero);

        _input.InGame.Shoot.performed -= context => _inputSO.OnShoot(true);
        _input.InGame.Shoot.canceled -= context => _inputSO.OnShoot(false);

        _input.InGame.OpenInventory.performed -= context => _inputSO.OnInventory(true);
        _input.InGame.OpenInventory.canceled -= context => _inputSO.OnInventory(false);

        _input.InGame.SelectWeapon.performed -= context => _inputSO.OnSelectWeapon(_input.InGame.SelectWeapon.ReadValue<Vector2>());
        _input.InGame.SelectWeapon.canceled -= context => _inputSO.OnSelectWeapon(Vector2.zero);

        _input.InGame.Disable();
    }
    private void Update()
    {
        //find the last Input Device used and set a bool.
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
            _inputSO._isInputGamepad = true;
        }
        else
        {
            _inputSO._isInputGamepad = false;
        }
    }
}
