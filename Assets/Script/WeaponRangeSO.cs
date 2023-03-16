using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="weaponRangeSO", menuName = "weapon/weaponRangeSO", order = 2)]
public class WeaponRangeSO : ScriptableObject
{
    public int id;
    public float reloadTime;
    public float bulletSpeed;
    public int damage;
    public GameObject bullet;
    public GameObject weaponPrefab;
    public GameObject buttonPrefab;
    public GameObject buttonInstance;
}
