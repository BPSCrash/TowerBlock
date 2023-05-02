using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _cameraPosition;
    void Start()
    {
        _cameraPosition = this.transform.position;
    }

    public void MoveCamera()
    {
        _cameraPosition.y += 2f * Time.deltaTime;
        this.transform.position = _cameraPosition;
    }
}
