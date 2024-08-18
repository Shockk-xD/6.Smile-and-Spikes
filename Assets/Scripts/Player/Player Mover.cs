using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForceSpeed = 200f;

    private ConstantForce2D _constantForce;
    private bool _isJumping = false;

    private void Start()
    {
        _constantForce = GetComponent<ConstantForce2D>();
        _constantForce.force = new Vector2(_jumpForceSpeed, _constantForce.force.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _constantForce.force = new Vector2(-_constantForce.force.x, _constantForce.force.y);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        _isJumping = false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isJumping = true;
    }
}
