using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointeurToWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject weaponPosition;

    float baseDistanceValue;

    float ArrowScale;
    
    float distance;

    [SerializeField]
    float closeScale;

    [SerializeField]
    float farScale;

    private void Start()
    {
        baseDistanceValue = Vector2.Distance((Vector2)weaponPosition.transform.position, (Vector2)transform.position);
    }

    private void Update()
    {
        if(weaponPosition == null)
        {
            Destroy(gameObject);
        }
        else
        {
            LookToWeapon();

            NearObject();
        }
    }

    void LookToWeapon()
    {
        Vector2 direction = ((Vector2)weaponPosition.transform.position - (Vector2)transform.position);
        transform.up = direction;
    }

    void NearObject()
    {
        distance = Vector2.Distance((Vector2)weaponPosition.transform.position, (Vector2)transform.position) / baseDistanceValue;

        ArrowScale = Mathf.Lerp(closeScale, farScale, distance);

        transform.GetChild(0).localScale = new Vector3(ArrowScale, ArrowScale, ArrowScale);
    }
}
