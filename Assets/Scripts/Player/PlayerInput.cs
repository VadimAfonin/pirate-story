using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalDirection;
    public bool isJumpButtonPressed;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);        
    }
}
