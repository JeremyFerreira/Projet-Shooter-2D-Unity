using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSaveInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] WeaponRangeSO[] _weapons;

    private void Start()
    {
        Load();
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    private void Load()
    {
        string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/PlayerInventory.json");
        List<int> id = new List<int>();

        for(int i = 0; i < json.Length; i+=2)
        {
            id.Add(int.Parse(json[i].ToString()));
        }

        foreach(int ids in id)
        {
            //parce que le gun (id = 2) est donné directement au start
            if(ids!=2)
            {
                _inventory.weapons.Add(_weapons[ids]);
                _weapons[ids].buttonInstance = Instantiate(_weapons[ids].buttonPrefab);
            }
            
        }
    }
    private void Save()
    {
        string json = "";
        for (int i =0; i<_inventory.weapons.Count;i++)
        {
            json += _inventory.weapons[i].id.ToString();
            json+= "/";
        }
        
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerInventory.json", json);
    }
}
