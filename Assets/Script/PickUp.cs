using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] WeaponRangeSO weaponRangeSO;
    [SerializeField] PlayerInventory playerInventory;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            playerInventory.weapons.Add(weaponRangeSO);
            weaponRangeSO.buttonInstance = Instantiate(weaponRangeSO.buttonPrefab);
            Destroy(this.gameObject);
        }
    }
}
