using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] WeaponRangeSO weaponRange;
    [SerializeField] EventSO switchWeaponEvent;
    public void SwitchWeapon()
    {
        switchWeaponEvent.OnLauchEventWeaponRange?.Invoke(weaponRange);
    }
}
