using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputSO", menuName = "Input/InputSO", order = 1)]
public class InputSO : ScriptableObject
{
    public event Action<Vector2> OnMoveChanged;
    public event Action<Vector2> OnLookChanged;
    public event Action<Vector2> OnLookGamePadChanged;
    public event Action<bool> OnShootActive;
    public event Action<bool> OnInventoryActive;
    public bool _isInputManette;
    public void OnMove(Vector2 value)
    {
        OnMoveChanged?.Invoke(value);
    }
    public void OnLook(Vector2 value)
    {
        OnLookChanged?.Invoke(value);
    }
    public void OnLookGamePad(Vector2 value)
    {
        OnLookGamePadChanged?.Invoke(value);
    }
    public void OnShoot(bool value)
    {
        OnShootActive?.Invoke(value);
    }
    public void OnInventory(bool value)
    {
        OnInventoryActive?.Invoke(value);
    }

}
