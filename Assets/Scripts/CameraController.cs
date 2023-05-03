using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _cameraMovementAmount = 2.5f;
    private Vector3 _cameraPosition;
    void Start()
    {
        _cameraPosition = this.transform.position;
    }

    public IEnumerator MoveCamera()
    {
        _cameraPosition.y += _cameraMovementAmount * Time.deltaTime;
        this.transform.position = _cameraPosition;
        yield return null;
    }
    
}
