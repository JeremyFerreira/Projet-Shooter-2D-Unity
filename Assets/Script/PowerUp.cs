using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpEnum
{
    life,
    explosion
}
public class PowerUp : MonoBehaviour
{
    [SerializeField] PowerUpEnum _powerUpEnum;
    [SerializeField] GameObject _explosion;
    private void Awake()
    {
        _powerUpEnum = (PowerUpEnum) UnityEngine.Random.Range(0, Enum.GetNames(typeof(PowerUpEnum)).Length);
        switch (_powerUpEnum)
        {
            case PowerUpEnum.life:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case PowerUpEnum.explosion:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            switch(_powerUpEnum)
            {
                case PowerUpEnum.life:
                    LifePowerUp(collision.gameObject);
                    break;
                case PowerUpEnum.explosion:
                    ExplosionPowerUp(collision.gameObject);
                    break;
            }
            Destroy(this.gameObject);
        }
    }
    void LifePowerUp(GameObject player)
    {
        player.GetComponent<playerLife>().AddLife(1);
    }
    void ExplosionPowerUp(GameObject player)
    {
        Instantiate(_explosion, player.transform.position, Quaternion.identity);
    }
}
