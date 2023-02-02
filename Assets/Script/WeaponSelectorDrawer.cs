using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSelectorDrawer : MonoBehaviour
{
    [Range(100f, 1000f)]
    [SerializeField] float radius;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] Transform buttonParent;
    [SerializeField] InputSO _inputSO;
    [SerializeField] Transform _IndicatorJoystick;
    float TAU = Mathf.PI * 2;
    
    [SerializeField] GameObject seperateButtonsLine;

    private void OnEnable()
    {
        _inputSO.OnInventoryActive += PlaceButtonsInCircle;
        _inputSO.OnMoveChanged += SelectButtonGamepad;
    }
    private void OnDisable()
    {
        _inputSO.OnInventoryActive -= PlaceButtonsInCircle;
        _inputSO.OnMoveChanged -= SelectButtonGamepad;
    }
    public void PlaceButtonsInCircle(bool value)
    {
        _IndicatorJoystick.gameObject.SetActive(_inputSO._isInputManette);
        if (value)
        {
            
            for (int i = 0; i < inventory.weapons.Count; i++)
            {
                float angle = TAU * i / inventory.weapons.Count;
                Vector3 circularPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                inventory.weapons[i].buttonInstance.transform.parent = buttonParent;
                inventory.weapons[i].buttonInstance.transform.position = new Vector3(960, 540, 0) + circularPos * radius;
            }
        }
        else
        {
            if(_inputSO._isInputManette)
            {
                List<Vector3> buttonDirections = new List<Vector3>();
                for (int i = 0; i < inventory.weapons.Count; i++)
                {
                    buttonDirections.Add(inventory.weapons[i].buttonInstance.transform.position - _IndicatorJoystick.position);
                }
                FindBiggestDot(buttonDirections).GetComponent<WeaponButton>().SwitchWeapon();
            }
            
        }
    }
    private void SelectButtonGamepad(Vector2 direction)
    {
        _IndicatorJoystick.up = direction;
    }
    GameObject FindBiggestDot(List<Vector3> directions)
    {
        GameObject biggestDotGameObject = inventory.weapons[0].buttonInstance;
        float biggestDot = Vector3.Dot(directions[0], _IndicatorJoystick.up);
        for (int i = 1; i < inventory.weapons.Count; i++)
        {
            float dot = Vector3.Dot(directions[i], _IndicatorJoystick.up);
            if (dot > biggestDot)
            {
                biggestDot = dot;
                biggestDotGameObject = inventory.weapons[i].buttonInstance;
            }
        }
        return biggestDotGameObject;
    }
}
