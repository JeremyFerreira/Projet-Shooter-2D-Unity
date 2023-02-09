using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "score")]
public class Score : ScriptableObject
{
    public int _score;
    public event Action<int> OnValueChangedEvent;
    public void OnValueChanged(int value)
    {
        _score += value;
        OnValueChangedEvent?.Invoke(_score);
    }
}
