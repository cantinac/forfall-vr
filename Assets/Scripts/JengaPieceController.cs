using UnityEngine;

public class JengaPieceController : MonoBehaviour
{

    [SerializeField] private Color[] randomColors;

    private new Renderer renderer;
    private Rigidbody rb;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {

        renderer = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody>();

        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;

    }

    private void OnEnable()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = startRotation;

        renderer.material.color = randomColors[Random.Range(0, randomColors.Length)];

    }

}
