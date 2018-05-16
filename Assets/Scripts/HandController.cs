using UnityEngine;

public class HandController : MonoBehaviour
{

    public void ReleaseItem()
    {

        GameObject item = gameObject.transform.Find("Item").gameObject;

        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();
        Rigidbody handRigidbody = gameObject.transform.GetComponent<Rigidbody>();

        itemRigidbody.isKinematic = false;

        itemRigidbody.velocity = handRigidbody.velocity;
        itemRigidbody.angularVelocity = handRigidbody.angularVelocity;

    }

}
