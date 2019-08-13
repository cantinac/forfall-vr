using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    private const float SCALE_SPEED = 0.1f;

    private const int NUM_OF_BRICKS_IN_A_ROW = 3;

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    [Range(0, 5)]
    private float scaleOfTower = 0.5f;

    [SerializeField]
    private int numOfRows = 8;

    private readonly List<GameObject> towerBlocks = new List<GameObject>();

    private readonly WaitForSeconds delayBetweenPlacingBlocks = new WaitForSeconds(0.05f);

    private Coroutine generateTower;

    private void Start()
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

                towerBlocks.Add(block);

            }

        }

        InitGenerateTower();

    }

    private void Update()
    {

        gameObject.transform.localScale = Vector3.one * scaleOfTower;

        if (Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0)
        {

            scaleOfTower += SCALE_SPEED * Time.deltaTime;

        }
        else if (Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0)
        {

            scaleOfTower -= SCALE_SPEED * Time.deltaTime;

        }

    }

    [ContextMenu("InitGenerateTower")]
    public void InitGenerateTower()
    {

        DestroyTower();

        StopAllCoroutines();

        StartCoroutine(GenerateTower());

    }

    private IEnumerator GenerateTower()
    {

        for (var i = 0; i < towerBlocks.Count; i += 1)
        {

            towerBlocks[i].SetActive(true);

            yield return delayBetweenPlacingBlocks;

        }

        yield return null;

    }

    private void DestroyTower()
    {

        for (var i = 0; i < towerBlocks.Count; i += 1)
        {

            towerBlocks[i].SetActive(false);

        }

    }

    [ContextMenu("BlowUpTower")]
    public void BlowUpTower()
    {

        var explosionPos = gameObject.transform.position;

        var colliders = Physics.OverlapSphere(explosionPos, 100f);

        foreach (var hit in colliders)
        {

            var rb = hit.GetComponent<Rigidbody>();

            if (rb == null)
            {
                continue;
            }

            rb.AddExplosionForce(500f, explosionPos, 100f);
            rb.AddExplosionForce(100f, rb.gameObject.transform.position, 1f);

        }

    }

}
