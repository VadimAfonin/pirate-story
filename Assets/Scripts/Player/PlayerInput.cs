using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public float HorizontalDirection;
    public bool IsJumpButtonPressed;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        HorizontalDirection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
        IsJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);

        _playerMovement.Move(HorizontalDirection, IsJumpButtonPressed);
    }
}
