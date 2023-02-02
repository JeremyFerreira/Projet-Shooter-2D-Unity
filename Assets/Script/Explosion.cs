using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float _speed;
    float timer;
    private void Awake()
    {
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
       transform.localScale += Time.deltaTime*_speed*Vector3.one;
        timer+= Time.deltaTime;
        if(timer>1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            collision.GetComponent<EnemyHealth>().UpdateHealth(1000);
        }
    }
}
