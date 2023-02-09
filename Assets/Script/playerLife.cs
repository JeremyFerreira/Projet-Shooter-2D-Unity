using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour, IDamageable
{
    [SerializeField] int _life;
    int lifeMax;
    [SerializeField] Slider _lifeSlider;
    [SerializeField] EventSO _gameOver;
    Animator _animator;

    private void Awake()
    {
        lifeMax = _life;
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
            if(_life < 0)
            {
                _gameOver.OnLaunchEvent?.Invoke();
            }
        }
    }
    public void AddLife(int value)
    {
        _life += value;
        UpdateUILifeSlider();
    }

    public void TakeDamage(int damage)
    {
        _life -= damage;
        UpdateUILifeSlider();
        _animator.CrossFade("PlayerHit", 0);
    }
    void UpdateUILifeSlider()
    {
        _lifeSlider.value = (float)_life / (float)lifeMax;
    }
}
