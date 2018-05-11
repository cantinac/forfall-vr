using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private Color[] randomColors;

    private void Awake()
    {

        gameObject.GetComponent<Renderer>().material.color = randomColors[Random.Range(0, randomColors.Length)];

    }

}
