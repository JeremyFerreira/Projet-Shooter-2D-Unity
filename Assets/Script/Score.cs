using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "score")]
public class Score : ScriptableObject
{
    public int _score;
    public delegate void LaunchEvent();
    public LaunchEvent OnLaunchEvent;
}
