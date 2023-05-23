using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    [SerializeField] float _rotationRadius = 2f, _angularSpeed = 2f;
    [SerializeField] float _duration = 1f;
    private LogicScript _logic;
    float _angle = 0f;
    BlockSpawn _blockSpawnScript;
    Rigidbody2D _rigidBody;
    bool _shouldKeepScore = true;
    bool _isGameFailable;

    private void Start()
    {
        _logic = FindAnyObjectByType<LogicScript>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _blockSpawnScript = FindObjectOfType<BlockSpawn>();
        _isGameFailable = _logic.GetGameFailable();
        SpawnAnimation();
    }

    private void FixedUpdate()
    {
        if (_rigidBody.gravityScale == 0)
        {
            BlockIdleMovement();
        }
    }

    void SpawnAnimation()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMove(new Vector3(this.transform.position.x + 2.8f, this.transform.position.y + -2.6f, 0), _duration * 0.5f).SetEase(Ease.InOutSine));
        sequence.Append(transform.DOLocalMove(new Vector3(this.transform.position.x, this.transform.position.y + -3.6f, 0), _duration * 0.5f).SetEase(Ease.InSine));

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

                if (_shouldKeepScore)
                {
                    _logic.AddScore(false);
                    _shouldKeepScore = false;
                }
                _logic.SetGameFailable();
                StartCoroutine(_blockSpawnScript.SpawnBlockWithDelay(0));
            }
            else
            {
                _shouldKeepScore = false;
                _logic.GameOver();
            }
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            if (_shouldKeepScore)
            {
                _logic.AddScore(false);
                _shouldKeepScore = false;
            }
            StartCoroutine(_blockSpawnScript.SpawnBlockWithDelay(0.5f));
        }
    }
}