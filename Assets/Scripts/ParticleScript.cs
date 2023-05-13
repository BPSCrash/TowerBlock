using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] ParticleSystem _leftParticles;
    [SerializeField] ParticleSystem _rightParticles;
    bool _shouldEmmitParticles = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_shouldEmmitParticles)
        {
            if (collision.gameObject.tag == "ParticleTrigger")
            {
                _leftParticles.Play();
                _rightParticles.Play();
                _shouldEmmitParticles = false;
            }
            else if (collision.gameObject.tag == "Ground")
            {
                _shouldEmmitParticles = false;
            } else if (collision.gameObject.tag == "Block")
            {
                _shouldEmmitParticles = false;
            }
        }
    }
}