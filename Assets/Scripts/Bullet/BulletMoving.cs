using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void FixedUpdate()
    {
        transform.parent.Translate(speed * Vector2.up * Time.fixedDeltaTime);
    }
}
