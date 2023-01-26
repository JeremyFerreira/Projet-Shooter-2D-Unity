using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int life = 100;
    int maxLife;
    [SerializeField] Slider healthSlider;
    [SerializeField] Score score;
    [SerializeField] GameObject particuleDeath;

    private void OnEnable()
    {
        maxLife = life;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            UpdateHealth(collision.GetComponent<BulletStats>().damage);
            Instantiate(particuleDeath, transform.position, Quaternion.identity).transform.up = collision.GetComponent<Rigidbody2D>().velocity;
            Destroy(collision.gameObject);
        }
    }
    public void UpdateHealth(int health)
    {
        life -= health;
        healthSlider.value = (float)life / (float)maxLife;
        if (life <= 0)
        {
            Death();
            score._score += 100;
            score.OnLaunchEvent?.Invoke();
        }
    }
    void Death()
    {
        
        Destroy(gameObject);
        
    }
}
