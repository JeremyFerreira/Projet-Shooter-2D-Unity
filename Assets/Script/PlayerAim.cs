using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAim : MonoBehaviour
{
    //Input//

    [SerializeField] InputSO _inputSO;
    Vector2 lookInput;
    [SerializeField] Transform weapon;
    private void MylookInput(Vector2 direction)
    {
        lookInput = direction;
    }
    private void MylookGamePadInput(Vector2 direction)
    {
        lookInput = direction;
    }

    private void OnEnable()
    {
#if PLATFORM_ANDROID
        _inputSO.OnLookGamePadChanged += MylookInput;
#else
        _inputSO.OnLookChanged += MylookInput;
        _inputSO.OnLookGamePadChanged += MylookGamePadInput;
#endif

    }
    private void OnDisable()
    {
#if PLATFORM_ANDROID
        _inputSO.OnLookGamePadChanged -= MylookInput;
#else
        _inputSO.OnLookChanged -= MylookInput;
        _inputSO.OnLookGamePadChanged -= MylookGamePadInput;
#endif
    }

    private void Update()
    {
        Look();
        LookGamePad();
    }
    private void Look()
    {
#if PLATFORM_ANDROID
        Vector3 direction2 = Vector3.up * lookInput.y + Vector3.right * lookInput.x;
        //le player regarde dans la direction de son mouvement si aucun input
        if (Mathf.Abs(lookInput.x) > 0.1f || Mathf.Abs(lookInput.y) > 0.1f)
        {
            weapon.transform.up = direction2;
        }
#else
        if (!_inputSO._isInputGamepad)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(lookInput);
            Vector2 direction = (mouseWorldPosition - (Vector2)transform.position);
            weapon.transform.up = direction;
        }
#endif


    }
    private void LookGamePad()
    {
        if(_inputSO._isInputGamepad)
        {
            Vector3 direction2 = Vector3.up * lookInput.y + Vector3.right * lookInput.x;
            //le player regarde dans la direction de son mouvement si aucun input
            if (Mathf.Abs(lookInput.x) > 0.1f || Mathf.Abs(lookInput.y) > 0.1f)
            {
                weapon.transform.up = direction2;
            }
        }
    }
}