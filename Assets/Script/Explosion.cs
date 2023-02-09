using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float _speed;
    float _timer;

    private void Awake()
    {
        _timer = 0;
    }

    void Update()
    {
       transform.localScale += Time.deltaTime*_speed*Vector3.one;
        _timer+= Time.deltaTime;
        if(_timer > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            if(collision.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(1000);
            }
        }
    }
}
