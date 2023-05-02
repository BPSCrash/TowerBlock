using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] GameObject BlockPrefab;
    GameObject _currentBlock;
    bool _hangingBlockExists = false;

    private void Start()
    {
        SpawnBlock();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBlock();
        }
    }

    public void SpawnBlock()
    {
        if (!_hangingBlockExists)
        {
       _hangingBlockExists = true;
       _currentBlock = Instantiate(BlockPrefab, new Vector3(transform.position.x , transform.position.y, 0f), transform.rotation);
        }
    }

    void DropBlock()
    {
        _hangingBlockExists = false;
        _currentBlock.GetComponent<Rigidbody2D>().gravityScale += 1f;
    }
}
