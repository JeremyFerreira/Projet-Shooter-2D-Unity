using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    //playerVariables

    [SerializeField] float _acceleration;
    [SerializeField] float _maxSpeed;

    [SerializeField] Rigidbody2D _rb;

    //Input//

    [SerializeField] InputSO _inputSO;
    Vector2 moveInput;
    Vector2 lookInput;
    Vector2 lookGamePadInput;
    [SerializeField] Transform weapon;
    [SerializeField] PlayerRefernceSO _playerRefernceSO;
    private void MyMoveInput(Vector2 direction)
    {
        moveInput = direction;
    }
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
        _inputSO.OnMoveChanged += MyMoveInput;
        _inputSO.OnLookChanged += MylookInput;
        _inputSO.OnLookGamePadChanged += MylookGamePadInput;
    }
    private void OnDisable()
    {
        _inputSO.OnMoveChanged -= MyMoveInput;
        _inputSO.OnLookChanged -= MylookInput;
        _inputSO.OnLookGamePadChanged -= MylookGamePadInput;
    }
    private void Awake()
    {
        _playerRefernceSO.player = this.gameObject;
    }

    private void FixedUpdate()
    {
        Move();
        Look();
        LookGamePad();
    }
    private void Move()
    {
        if(_rb.velocity.sqrMagnitude <= _maxSpeed*_maxSpeed)
        {
            Vector2 direction = new Vector2(moveInput.x, moveInput.y).normalized;
            _rb.AddForce(direction * _acceleration * Time.deltaTime);
        }
    }
    private void Look()
    {
        if(!_inputSO._isInputManette)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(lookInput);
            Vector2 direction = (mouseWorldPosition - (Vector2)transform.position);
            weapon.transform.up = direction;
        }
    }
    private void LookGamePad()
    {
        if(_inputSO._isInputManette)
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