using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroySelf : MonoBehaviour
{
    [SerializeField] private float deathTime = 2f;
    void Start()
    {
        Invoke(nameof(DestroySelf), deathTime);
    }

    private void DestroySelf()
    {
        Destroy(transform.parent.gameObject);
    }
}
