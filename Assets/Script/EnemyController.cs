using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] PlayerRefernceSO _playerRefernceSO;
    [SerializeField] float speed;
    Rigidbody2D rb;
    bool isAttacking;

    private void Awake()
    {
        isAttacking = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //only move when the ennemy has finished spawn animation.
        if(isAttacking)
        {
            rb.velocity = (_playerRefernceSO.player.transform.position-transform.position).normalized * speed;
        }
    }
    //is called by event in animation
    public void AttackPlayer()
    {
        isAttacking = true;
    }
}
