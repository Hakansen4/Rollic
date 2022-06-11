using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool _active;
    private float _forwardSpeed;
    private float _xSpeed;


    public void Start()
    {
        _forwardSpeed = 2f;
        _xSpeed = 5f;
    }

    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }

    private void FixedUpdate()
    {
        if (_active)
        {
            float horizontal = Input.GetAxis("Horizontal");
            var vec = transform.position;
            var pos = vec += new Vector3(_xSpeed * Time.fixedDeltaTime * horizontal, 0, 0);
            pos.x = Mathf.Clamp(pos.x, -1.85f, 1.85f);
            transform.position = pos;
            transform.Translate(0, 0, -Time.deltaTime * _forwardSpeed);
        }
    }
}
