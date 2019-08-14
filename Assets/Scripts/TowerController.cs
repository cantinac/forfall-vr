using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    public float ScaleOfTower { get; set; } = 0.5f;

    [SerializeField]
    private LayerMask _layerMask;

    private readonly WaitForSeconds delayBetweenPlacingBlocks = new WaitForSeconds(0.05f);

    private TowerBuilder _towerBuilder;

    private Coroutine generateTower;

    private void Awake()
    {

        _towerBuilder = gameObject.GetComponent<TowerBuilder>();

    }

    private void Start()
    {

        InitGenerateTower();

    }

    private void Update()
    {

        gameObject.transform.localScale = Vector3.one * ScaleOfTower;

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

        for (var i = 0; i < _towerBuilder.TowerBlocks.Count; i += 1)
        {

            _towerBuilder.TowerBlocks[i].SetActive(true);

            yield return delayBetweenPlacingBlocks;

        }

        yield return null;

    }

    private void DestroyTower()
    {

        for (var i = 0; i < _towerBuilder.TowerBlocks.Count; i += 1)
        {

            _towerBuilder.TowerBlocks[i].SetActive(false);

        }

    }

    [ContextMenu("BlowUpTower")]
    public void BlowUpTower()
    {

        var explosionPos = gameObject.transform.position;

        var colliders = Physics.OverlapSphere(explosionPos, 100f, _layerMask);

        foreach (var hit in colliders)
        {

            var rb = hit.GetComponent<Rigidbody>();

            rb.AddExplosionForce(500f, explosionPos, 100f);
            rb.AddExplosionForce(100f, rb.gameObject.transform.position, 1f);

        }

    }

}
