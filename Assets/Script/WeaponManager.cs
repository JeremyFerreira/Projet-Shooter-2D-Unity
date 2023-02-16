using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] InputSO _inputSO;
    [SerializeField] WeaponRangeSO Gun;
    WeaponRangeSO currentweaponData;
    [SerializeField] Transform GunTip;
    bool isShooting;
    float reloadTime;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] EventSO switchWeaponEvent;
    [SerializeField] Transform weaponParent;
    GameObject currentWeaponObject;
    private void Awake()
    {
        inventory.weapons.Clear();
        inventory.weapons.Add(Gun);
        Gun.buttonInstance = Instantiate(Gun.buttonPrefab);
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        _inputSO.OnShootActive += ShootInput;
        switchWeaponEvent.OnLauchEventWeaponRange += ChangeWeapon;
    }
    void OnDisable()
    {
        _inputSO.OnShootActive -= ShootInput;
        switchWeaponEvent.OnLauchEventWeaponRange -= ChangeWeapon;
    }

    // Update is called once per frame
    private void Start()
    {
        ChangeWeapon(Gun);
    }
    void ShootInput(bool value)
    {
        isShooting = value;
    }
    private void FixedUpdate()
    {
        Shoot();
    }
    void Shoot()
    {
        reloadTime -= Time.deltaTime;
        if (reloadTime < 0 && isShooting)
        {
             GameObject bullet = Instantiate(currentweaponData.bullet, currentWeaponObject.transform.GetChild(0).transform.position, Quaternion.identity);
             bullet.GetComponent<Rigidbody2D>().velocity = currentweaponData.bulletSpeed * transform.up;
             bullet.GetComponent<BulletStats>().damage = currentweaponData.damage;
             reloadTime = currentweaponData.reloadTime;
        }
#if PLATFORM_ANDROID
        if (reloadTime < 0)
        {
            GameObject bullet = Instantiate(currentweaponData.bullet, currentWeaponObject.transform.GetChild(0).transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = currentweaponData.bulletSpeed * transform.up;
            bullet.GetComponent<BulletStats>().damage = currentweaponData.damage;
            reloadTime = currentweaponData.reloadTime;
        }
#endif

    }
    void ChangeWeapon(WeaponRangeSO weapon)
    {
        currentweaponData = weapon;
        if(currentWeaponObject != null)
        {
            Destroy(currentWeaponObject);
        }
        currentWeaponObject = Instantiate(weapon.weaponPrefab, GunTip.transform.position, GunTip.rotation);
        currentWeaponObject.transform.parent = weaponParent;
        reloadTime = currentweaponData.reloadTime;
    }
}
