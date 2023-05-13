using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    [SerializeField] float _rotationRadius = 2f, _angularSpeed = 2f;
    float _angle = 0f;
    BlockSpawn _blockSpawnScript;
    Rigidbody2D _rigidBody;
    bool _isGameFailable = false;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _blockSpawnScript = FindObjectOfType<BlockSpawn>();
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
        _rigidBody.velocity = new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle) * _rotationRadius / 2 * _angularSpeed);
        _angle = _angle + Time.deltaTime * _angularSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!_isGameFailable)
            {
                _isGameFailable = true;
                StartCoroutine(_blockSpawnScript.SpawnBlockWithDelay(0));
            }
            else
            {
                Debug.Log("YOU FAILED : " + _isGameFailable);
            }
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            StartCoroutine(_blockSpawnScript.SpawnBlockWithDelay(0.5f));
        }
    }
}