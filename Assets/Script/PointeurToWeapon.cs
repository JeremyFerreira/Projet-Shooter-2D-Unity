using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointeurToWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPosition;
    private float _baseDistanceValue;
    private float _arrowScale;
    private float _distance;
    [SerializeField] private float _closeScale;
    [SerializeField] private float _farScale;

    private void Start()
    {
        _baseDistanceValue = Vector2.Distance((Vector2)_weaponPosition.transform.position, (Vector2)transform.position);
    }

    private void Update()
    {
        if(_weaponPosition == null)
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
        Vector2 direction = ((Vector2)_weaponPosition.transform.position - (Vector2)transform.position);
        transform.up = direction;
    }

    void NearObject()
    {
        _distance = Vector2.Distance((Vector2)_weaponPosition.transform.position, (Vector2)transform.position) / _baseDistanceValue;

        _arrowScale = Mathf.Lerp(_closeScale, _farScale, _distance);

        transform.GetChild(0).localScale = new Vector3(_arrowScale, _arrowScale, _arrowScale);
    }
}
