using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerScript : MonoBehaviour
{
    private bool _isBlockInTrigger = false;
    CameraController _cameraControllerScript;
    Coroutine _lastCoroutine = null;

    private void Start()
    {
        _cameraControllerScript = transform.parent.GetComponent<CameraController>();
    }

    // Logic for camera Movement
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            _lastCoroutine = StartCoroutine(CheckIfBlockInTrigger(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            StopCoroutine(_lastCoroutine);
            _isBlockInTrigger = false;
        }
    }

    IEnumerator CheckIfBlockInTrigger(Collider2D collision)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if(collision.gameObject.CompareTag("Block"))
        {
            _isBlockInTrigger = true;
        }
    }

    private void Update()
    {
        if (_isBlockInTrigger)
        {
            StartCoroutine(_cameraControllerScript.MoveCamera());
        }
    }
}
