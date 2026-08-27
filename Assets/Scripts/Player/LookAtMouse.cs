using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private Vector3 mouseScreenPos;
    [SerializeField] private Vector3 mouseWordPos;
    [SerializeField] private float rotSpeed = 720f;

    private void Update()
    {
        GetMouseWordPosition();
        LookAtMouseDirection();
    }

    private void GetMouseWordPosition()
    {
        mouseScreenPos = Mouse.current.position.value;
        mouseWordPos =  Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private void LookAtMouseDirection()
    {
        /*
        float alpha = Mathf.Atan2(mouseWordPos.x, mouseWordPos.y);
        float alpha_in_degree = alpha / Mathf.PI;
        Quaternion curRot = transform.parent.rotation;
        curRot.z = (-1) * alpha_in_degree;
        transform.parent.rotation = curRot; */

        this.LookAtMouseWithSmoothSpeed(rotSpeed);
    }

    private void LookAtMouseImmediately()
    {
        Vector2 direction = mouseWordPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float offset = -90f; //because the Sprite is facing up
        transform.parent.rotation = Quaternion.Euler(0f, 0f, angle + offset);
    }

    private void LookAtMouseWithSmoothSpeed(float rotSpeed)
    {
        Vector2 direction = mouseWordPos - transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float offset = -90f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle + offset);

        // Rotation by time
        transform.parent.rotation = Quaternion.RotateTowards(
            transform.parent.rotation,
            targetRotation,
            rotSpeed * Time.deltaTime
        );
    }
}
