using UnityEngine;

public class HandController : MonoBehaviour
{

    [SerializeField] private TowerController towerController;

    private bool canPickupItem = false;

    private GameObject item;

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name.Contains("Bucket") && canPickupItem && item == null)
        {

            item = other.gameObject.GetComponent<BucketController>().GrabItem(gameObject.transform);

        }

    }

    public void ReleaseItem()
    {

        if (item)
        {

            Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

            item.transform.SetParent(null);

            itemRigidbody.isKinematic = false;

            item = null;

        }

    }

}
