using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float _durationBeforeSelfDescruct;
    // Start is called before the first frame update

    IEnumerator SelfDestruction(float _duration)
    {
        yield return new WaitForSeconds(_duration);
        Destroy(gameObject);

    }

    private void OnEnable()
    {
        StartCoroutine(SelfDestruction(_durationBeforeSelfDescruct));
    }
}
