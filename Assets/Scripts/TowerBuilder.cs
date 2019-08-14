using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    private const int NUM_OF_BRICKS_IN_A_ROW = 3;

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private int numOfRows = 8;

    private readonly List<GameObject> _towerBlocks = new List<GameObject>();

    public ReadOnlyCollection<GameObject> TowerBlocks => _towerBlocks.AsReadOnly();

    private Coroutine generateTower;

    private void Awake()
    {

        var blockBounds = blockPrefab.GetComponent<Renderer>().bounds;
        var blockExtents = blockBounds.extents;
        var blockSize = blockBounds.size;

        for (var i = 0; i < numOfRows; i += 1)
        {

            for (var j = 0; j < NUM_OF_BRICKS_IN_A_ROW; j += 1)
            {

                var block = Instantiate(blockPrefab, gameObject.transform);

                block.SetActive(false);

                var blockController = block.GetComponent<BlockController>();

                if (i % 2 == 0)
                {

                    blockController.startPosition = new Vector3(blockSize.x * j - 1, blockExtents.y + blockSize.y * i, 0);
                    blockController.startRotation = Quaternion.identity;

                }
                else
                {

                    blockController.startPosition = new Vector3(0, blockExtents.y + blockSize.y * i, blockSize.x * j - 1);
                    blockController.startRotation = Quaternion.Euler(0, 90, 0);

                }

                _towerBlocks.Add(block);

            }

        }

    }

}
