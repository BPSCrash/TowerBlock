using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private bool _isBlockInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            _isBlockInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            _isBlockInTrigger = false;
        }
    }

    private void Update()
    {
        if (_isBlockInTrigger)
        {
        transform.parent.GetComponent<CameraController>().MoveCamera();
        }
    }
}
