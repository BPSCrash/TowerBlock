using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    [SerializeField] GameObject _backgroundPrefab;
    public float Rotation;
    Camera _camera;
    bool _shouldCreateBackground = true;

    void Start()
    {
        _camera = Camera.main;
    }
    void isBackgroundVisible()
    {
        Vector3 backgroundPositionRelativeToCamera = _camera.WorldToScreenPoint(transform.position);
        if(_shouldCreateBackground && backgroundPositionRelativeToCamera.y < 230) SpawnNextBackGround();
        if (backgroundPositionRelativeToCamera.y < -330)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void SpawnNextBackGround()
    {
        _shouldCreateBackground = false;
        _backgroundPrefab = Instantiate(_backgroundPrefab, new Vector3(this.transform.position.x, this.transform.position.y + gameObject.GetComponent<Renderer>().bounds.size.y - 1, 0f), transform.rotation * Quaternion.Euler (0f, 0f, 180f));
    }

    void Update()
    {
        isBackgroundVisible();
    }
}
