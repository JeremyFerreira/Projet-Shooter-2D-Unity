using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSaveInventory : MonoBehaviour
{
    [SerializeField] private PlayerInventory _inventory;

    private void Awake()
    {
        Load();
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    private void Load()
    {
        
    }
    private void Save()
    {

    }
}
