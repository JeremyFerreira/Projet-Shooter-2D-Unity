using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int _life = 100;
    int _maxLife;
    [SerializeField] Slider healthSlider;
    [SerializeField] Score score;
    [SerializeField] GameObject particuleDeath;

    private void OnEnable()
    {
        _maxLife = _life;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            TakeDamage(collision.GetComponent<BulletStats>().damage);
            Instantiate(particuleDeath, transform.position, Quaternion.identity).transform.up = collision.GetComponent<Rigidbody2D>().velocity;
            Destroy(collision.gameObject);
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _life -= damage;
        healthSlider.value = (float)_life / (float)_maxLife;
        if (_life <= 0)
        {
            Death();
            score.OnValueChanged(100);
        }
    }
}
