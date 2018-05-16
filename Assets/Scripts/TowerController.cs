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

    private WaitForSeconds delayBetweenPlacingPiece = new WaitForSeconds(0.05f);

    private Coroutine generateTower;

    private void Start()
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

                jengaPiece.SetActive(false);

                towerPieces.Add(jengaPiece);

            }

            currentYOffset += towerPieces[towerPieces.Count - 1].GetComponent<Renderer>().bounds.size.y;

        }

        InitGenerateTower();

    }

    [ContextMenu("InitGenerateTower")]
    public void InitGenerateTower()
    {

        StartCoroutine("GenerateTower");

    }

    public IEnumerator GenerateTower()
    {

        for (int i = 0; i < towerPieces.Count; i += 1)
        {

            towerPieces[i].SetActive(true);

            yield return delayBetweenPlacingPiece;

        }

        yield return null;

    }

    [ContextMenu("DestroyTower")]
    public void DestroyTower()
    {

        StopAllCoroutines();

        for (int i = 0; i < towerPieces.Count; i += 1)
        {

            towerPieces[i].SetActive(false);

        }

    }

    [ContextMenu("BlowUpTower")]
    public void BlowUpTower()
    {

        Vector3 explosionPos = gameObject.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, 100f);

        foreach (Collider hit in colliders)
        {

            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {

                rb.AddExplosionForce(500f, explosionPos, 100f);
                rb.AddExplosionForce(100f, rb.gameObject.transform.position, 1f);

            }

        }

    }

}
