using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct JengaPieceLocation
{
    public Vector3 position;
    public Vector3 rotation;
}

public class TowerController : MonoBehaviour
{

    [SerializeField] private GameObject jengaPiecePrefab;
    [SerializeField] private List<JengaPieceLocation> jengaPieceLocations = new List<JengaPieceLocation>();
    [SerializeField] private int numOfRows = 5;

    private List<GameObject> towerPieces = new List<GameObject>();

    private Coroutine generateTower;

    private void Start()
    {

        InitGenerateTower();

    }

    [ContextMenu("InitGenerateTower")]
    private void InitGenerateTower()
    {

        StartCoroutine("GenerateTower");

    }

    public IEnumerator GenerateTower()
    {

        float currentYOffset = 0.5f;

        for (int row = 0; row < numOfRows; row += 1)
        {

            int jengaPieceLocationOffset = row % 2 == 0 ? 0 : 3;

            for (int i = jengaPieceLocationOffset; i < jengaPieceLocationOffset + (jengaPieceLocations.Count / 2); i += 1)
            {

                Vector3 jengaPiecePosition = gameObject.transform.position + jengaPieceLocations[i].position;

                jengaPiecePosition.y = jengaPiecePosition.y + currentYOffset;

                Quaternion jenaPieceRotation = Quaternion.Euler(jengaPieceLocations[i].rotation);

                GameObject jengaPiece = Instantiate(jengaPiecePrefab, jengaPiecePosition, jenaPieceRotation);

                towerPieces.Add(jengaPiece);

                yield return new WaitForSeconds(0.1f);

            }

            currentYOffset += towerPieces[towerPieces.Count - 1].GetComponent<Renderer>().bounds.size.y;

        }

    }

    [ContextMenu("DestoryTower")]
    private void DestoryTower()
    {

        for (int i = 0; i < towerPieces.Count; i += 1)
        {

            Destroy(towerPieces[i]);

        }

        towerPieces.Clear();

    }

    [ContextMenu("BlowUpTower")]
    private void BlowUpTower()
    {

        Vector3 explosionPos = towerPieces[towerPieces.Count / 2].transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, 100f);

        foreach (Collider hit in colliders)
        {

            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {

                rb.AddExplosionForce(1000f, explosionPos, 100f);

            }

        }

    }

}
