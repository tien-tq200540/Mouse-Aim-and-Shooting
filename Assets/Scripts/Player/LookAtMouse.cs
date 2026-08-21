using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private Vector2 mouseScreenPos;
    [SerializeField] private Vector2 mouseWordPos;

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
        float alpha = Mathf.Atan2(mouseWordPos.x, mouseWordPos.y);
        float alpha_in_degree = alpha / Mathf.PI;
        Quaternion curRot = transform.parent.rotation;
        curRot.z = (-1) * alpha_in_degree;
        transform.parent.rotation = curRot;
    }
}
