using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] ParticleSystem _leftParticles;
    [SerializeField] ParticleSystem _rightParticles;
    private LogicScript _logic;
    bool _shouldEmmitParticles = true;
    bool _shouldAddScore = true;


    private void Start()
    {
        _logic = FindObjectOfType<LogicScript>();
    }

    public void DeactivateTraking()
    {
        _shouldAddScore = false;
        _shouldEmmitParticles = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_shouldEmmitParticles)
        {
            if (collision.gameObject.tag == "ParticleTrigger")
            {
                _shouldEmmitParticles = false;
                _leftParticles.Play();
                _rightParticles.Play();
                if (_shouldAddScore)
                {
                    _shouldAddScore = false;
                    _logic.AddScore(true);
                }

            }
            else if (collision.gameObject.tag == "Ground")
            {
                _shouldEmmitParticles = false;
                _shouldAddScore = false;
            }
            else if (collision.gameObject.tag == "Block")
            {
                _shouldAddScore = false;
                _shouldEmmitParticles = false;
            }
        }
    }
}