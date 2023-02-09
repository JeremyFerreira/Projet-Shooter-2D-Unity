using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //playerVariables

    [SerializeField] float _acceleration;
    [SerializeField] float _maxSpeed;

    Rigidbody2D _rb;

    //Input//

    [SerializeField] InputSO _inputSO;
    Vector2 _moveInput;
    [SerializeField] PlayerRefernceSO _playerRefernceSO;
    private void MyMoveInput(Vector2 direction)
    {
        _moveInput = direction;
    }
    private void OnEnable()
    {
        _inputSO.OnMoveChanged += MyMoveInput;
    }
    private void OnDisable()
    {
        _inputSO.OnMoveChanged -= MyMoveInput;
    }
    private void Awake()
    {
        _playerRefernceSO.player = this.gameObject;
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (_rb.velocity.sqrMagnitude <= _maxSpeed * _maxSpeed)
        {
            Vector2 direction = new Vector2(_moveInput.x, _moveInput.y).normalized;
            _rb.AddForce(direction * _acceleration * Time.fixedDeltaTime);
        }
    }
}
