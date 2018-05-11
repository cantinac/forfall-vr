using UnityEngine;

public class BucketController : MonoBehaviour
{

    [SerializeField] private GameObject[] itemsInBucketPrefabs;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Hand"))
        {

            GameObject item = Instantiate(
                itemsInBucketPrefabs[Random.Range(0, itemsInBucketPrefabs.Length)],
                other.gameObject.transform.position,
                other.gameObject.transform.rotation
            );

            item.GetComponent<Rigidbody>().isKinematic = true;

            item.transform.SetParent(other.gameObject.transform);

        }

    }

}
