using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : MonoBehaviour
{

    private const float MOVEMENT_SPEED = 6.0f;

    private const string AXIS_HORIZONTAL = "Oculus_CrossPlatform_PrimaryThumbstickHorizontal";
    private const string AXIS_VERTICAL = "Oculus_CrossPlatform_PrimaryThumbstickVertical";

    private CharacterController _characterController;

    private void Awake()
    {

        _characterController = gameObject.GetComponent<CharacterController>();

    }

    private void Update()
    {

        var movement = new Vector3(Input.GetAxis(AXIS_HORIZONTAL), 0.0f, Input.GetAxis(AXIS_VERTICAL)) * MOVEMENT_SPEED;

        _characterController.Move( movement* Time.deltaTime);

    }

}
