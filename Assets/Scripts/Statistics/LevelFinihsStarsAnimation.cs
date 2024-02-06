using UnityEngine;

public class LevelFinihsStarsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _uiPopup;

    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_uiPopup.activeSelf)
        {
            _anim.SetTrigger(GlobalStringVars.UiPopUpOpened);
        }
    }
}