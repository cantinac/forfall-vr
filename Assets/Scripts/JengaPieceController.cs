using UnityEngine;

public class JengaPieceController : MonoBehaviour
{

    [SerializeField] private Color[] randomColors;

    private void Awake()
    {

        gameObject.GetComponent<Renderer>().material.color = randomColors[Random.Range(0, randomColors.Length)];

    }

}
