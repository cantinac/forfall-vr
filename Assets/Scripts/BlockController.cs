using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class BlockController : MonoBehaviour
{

    [SerializeField]
    private Color[] randomColors;

    private new Renderer renderer;

    private Rigidbody rb;

    public Vector3 startPosition { get; set; }

    public Quaternion startRotation { get; set; }

    private void Awake()
    {

        renderer = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        gameObject.transform.localPosition = startPosition;
        gameObject.transform.localRotation = startRotation;

        renderer.material.color = randomColors[Random.Range(0, randomColors.Length)];

    }

}
