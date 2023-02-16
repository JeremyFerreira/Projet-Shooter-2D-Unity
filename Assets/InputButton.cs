using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButton : MonoBehaviour
{
    [SerializeField] private InputSO _inputSO;
    public void Shoot()
    {
        _inputSO.OnShoot(true);
    }
    public void CancelShoot()
    {
        _inputSO.OnShoot(false);
    }
    public void OpenInventory()
    {
        _inputSO.OnInventory(true);
    }
    public void CloseInventory()
    {
        _inputSO.OnInventory(false);
    }
}
