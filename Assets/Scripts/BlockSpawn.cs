using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] GameObject BlockPrefab;
    [SerializeField] LineRenderer _leftLine;
    [SerializeField] LineRenderer _rightLine;
    [SerializeField] int _ropeLenght = 4;
    GameObject _currentBlock;
    Vector3 _lastCameraPosition;
    bool _hangingBlockExists = false;
    bool _linesVisible = false;
    bool _isCameraMoving = false;

    private void Start()
    {
        _lastCameraPosition = this.gameObject.transform.position;
        StartCoroutine(SpawnBlockWithDelay(0));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBlock();
        }
        if (_hangingBlockExists)
        {
            AddLines();
        }
        MoveWithCamera();
    }

    public IEnumerator SpawnBlockWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        if (!_hangingBlockExists && !_isCameraMoving)
        {
            _hangingBlockExists = true;
            _linesVisible = true;
            _currentBlock = Instantiate(BlockPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0f), transform.rotation);
        }
        else if (_isCameraMoving)
        {
            StartCoroutine(SpawnBlockWithDelay(0.5f));
        }
    }

    void DropBlock()
    {
        _hangingBlockExists = false;
        _linesVisible = false;
        HideLines();
        _currentBlock.GetComponent<Rigidbody2D>().gravityScale += 1f;
    }

    void AddLines()
    {
        if (_linesVisible)
        {
            Bounds boxBounds = _currentBlock.GetComponent<BoxCollider2D>().bounds;
            Vector2 topRight = new Vector2(boxBounds.center.x + boxBounds.extents.x, boxBounds.center.y + boxBounds.extents.y);
            Vector2 topLeft = new Vector2(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y + boxBounds.extents.y);
            _rightLine.SetPosition(0, new Vector3(this.transform.position.x, this.transform.position.y + _ropeLenght));
            _rightLine.SetPosition(1, topRight);
            _leftLine.SetPosition(0, new Vector3(this.transform.position.x, this.transform.position.y + _ropeLenght));
            _leftLine.SetPosition(1, topLeft);
        }
    }

    void HideLines()
    {
        _rightLine.SetPosition(0, new Vector3());
        _rightLine.SetPosition(1, new Vector3());
        _leftLine.SetPosition(0, new Vector3());
        _leftLine.SetPosition(1, new Vector3());
    }

    void MoveWithCamera()
    {
        Vector3 currentCameraPosition = this.gameObject.transform.position;
        if (currentCameraPosition != _lastCameraPosition)
        {
            _isCameraMoving = true;
            transform.position = new Vector3(currentCameraPosition.x, currentCameraPosition.y, 0);
        }
        else
        {
            _isCameraMoving = false;
        }
        _lastCameraPosition = currentCameraPosition;
    }
}
