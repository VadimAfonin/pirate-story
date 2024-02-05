using UnityEngine;

public static class AnimatorConstants
{
    public static int _isRunningProperty = Animator.StringToHash("isRunning");
    public static int _isHurtingProperty = Animator.StringToHash("Hurt");
    public static int _isDeathProperty = Animator.StringToHash("isDeath");
    public static int _isAttackedProperty = Animator.StringToHash("youAttacked");
    public static int _isJumpingProperty = Animator.StringToHash("isJumping");
    public static int _isShootingProperty = Animator.StringToHash("Shoot");
}
