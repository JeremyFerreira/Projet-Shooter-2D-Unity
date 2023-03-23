using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<WeaponRangeSO> weapons;
    
}
