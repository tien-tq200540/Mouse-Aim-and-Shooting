using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform bullet;

    private void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            //Shoot
            Transform newBullet = Instantiate(bullet);
            newBullet.SetPositionAndRotation(transform.position, transform.parent.rotation);
        }
    }
}
