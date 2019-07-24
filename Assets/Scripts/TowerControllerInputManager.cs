using UnityEngine;

[RequireComponent(typeof(TowerController))]
public class TowerControllerInputManager : MonoBehaviour
{

    private TowerController _towerController;

    private void Awake()
    {

        _towerController = gameObject.GetComponent<TowerController>();

    }

    private void Update()
    {

        if (Input.GetButtonDown("Blow Up"))
        {
            _towerController.BlowUpTower();
        }

        if (Input.GetButtonDown("Reset"))
        {
            _towerController.InitGenerateTower();
        }

    }

}
