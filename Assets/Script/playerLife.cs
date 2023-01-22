using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    [SerializeField] int _life;
    int lifeMax;
    [SerializeField] Slider _lifeSlider;
    [SerializeField] EventSO _gameOver;

    private void Awake()
    {
        lifeMax = _life;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            UpdateLife(-1);
            Destroy(collision.gameObject);
            if(_life < 0)
            {
                _gameOver.OnLaunchEvent?.Invoke();
            }
        }
    }
    public void UpdateLife(int value)
    {
        _life += value;
        _lifeSlider.value = (float)_life / (float)lifeMax;
    }
}
