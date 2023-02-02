using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectorManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] InputSO _inputSO;
    private void OnEnable()
    {
        _inputSO.OnInventoryActive += OpenWeaponSelector;
    }
    private void OnDisable()
    {
        _inputSO.OnInventoryActive -= OpenWeaponSelector;
    }
    public void OpenWeaponSelector(bool value)
    {
        canvas.SetActive(value);


        Time.timeScale = value? 0:1;
    }
}
