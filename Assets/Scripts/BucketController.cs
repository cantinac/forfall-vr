using UnityEngine;

public class BucketController : MonoBehaviour
{

    [SerializeField] private GameObject[] itemsInBucketPrefabs;

    public GameObject GrabItem(Transform transform)
    {

        GameObject item = Instantiate(
            itemsInBucketPrefabs[Random.Range(0, itemsInBucketPrefabs.Length)],
            transform.position,
            transform.rotation
        );

        item.GetComponent<Rigidbody>().isKinematic = true;

        item.transform.SetParent(transform);

        return item;

    }

}
