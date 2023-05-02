using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    [SerializeField] float _rotationRadius = 2f, _angularSpeed = 2f;
    float _angle = 0f;
    Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_rigidBody.gravityScale == 0)
        {
            BlockIdleMovement();
        }
    }

    void BlockIdleMovement()
    {
        _rigidBody.velocity = new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle) * _rotationRadius / 3 * _angularSpeed);
        _angle = _angle + Time.deltaTime * _angularSpeed;
    }

}
