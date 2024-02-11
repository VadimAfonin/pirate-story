using System;
using System.Collections;
using UnityEngine;

public class BulletLifecycleController : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private float _deadTimer = 2;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_deadTimer);

        Destroy(gameObject);
    }
}

