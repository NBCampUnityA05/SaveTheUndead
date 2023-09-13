using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();

    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;   
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotatePlayer(newAimDirection);
    }
    private void RotatePlayer(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.GetComponentInChildren<SpriteRenderer>().flipX = Mathf.Abs(rotZ) > 90f;
    }

  
}
