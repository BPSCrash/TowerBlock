using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCheckScript : MonoBehaviour
{
    ParticleScript _parentParticleScript;
    private void Start()
    {
        _parentParticleScript = GetComponentInParent<ParticleScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block")){
            _parentParticleScript.DeactivateTraking();
        }
    }
}
