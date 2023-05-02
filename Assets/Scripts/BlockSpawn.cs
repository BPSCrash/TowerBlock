using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] GameObject BlockPrefab;
    GameObject currentBlock;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnBlock();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropBlock();
        }
    }

    void SpawnBlock()
    {
       currentBlock = Instantiate(BlockPrefab, new Vector3(transform.position.x , transform.position.y, 0f), transform.rotation);
    }

    void DropBlock()
    {
        currentBlock.GetComponent<Rigidbody2D>().gravityScale += 1f;
    }


}
