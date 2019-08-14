using UnityEngine;

[RequireComponent(typeof(TowerController))]
public class TowerControllerInputManager : MonoBehaviour
{

    private const float SCALE_SPEED = 0.1f;

    private const float MIN_SCALE = 0.1f;

    private const float MAX_SCALE = 2;

    private TowerController _towerController;

    private void Awake()
    {

        _towerController = gameObject.GetComponent<TowerController>();

    }

    private void Update()
    {

        if (Input.GetButtonDown("Oculus_CrossPlatform_Button_1") || Input.GetButtonDown("Oculus_CrossPlatform_Button_3"))
        {
            _towerController.BlowUpTower();
        }

        if (Input.GetButtonDown("Oculus_CrossPlatform_Button_2") || Input.GetButtonDown("Oculus_CrossPlatform_Button_4"))
        {
            _towerController.InitGenerateTower();
        }

        if (Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0)
        {

            _towerController.ScaleOfTower = Mathf.Clamp(_towerController.ScaleOfTower + SCALE_SPEED * Time.deltaTime, MIN_SCALE, MAX_SCALE);;

        }
        else if (Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0)
        {

            _towerController.ScaleOfTower = Mathf.Clamp(_towerController.ScaleOfTower - SCALE_SPEED * Time.deltaTime, MIN_SCALE, MAX_SCALE);

        }

    }

}
