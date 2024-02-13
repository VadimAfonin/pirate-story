using UnityEngine;
using TMPro;

public class BulletReloadController : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentAmmoText;
    [SerializeField] private int _allAmo; //в запасе
    [SerializeField] private int _gunBulletCapacity; //емкость барабана

    private Animator _anim;

    private int _currentAmmo; //в рожке 

    private void Awake()
    {
        _currentAmmo = _gunBulletCapacity;
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _currentAmmoText.text = (_currentAmmo + " / " + _allAmo);

        if (Input.GetButtonDown(GlobalStringVars.Fire1) && _currentAmmo > 0)
        {
            _anim.SetTrigger(AnimatorConstants._isShootingProperty);
            _currentAmmo--;
        }

        if (Input.GetKeyDown(KeyCode.R) && _allAmo > 0)
        {
            Reload();
        }
    }

    private void Reload()
    {
        int reason = _gunBulletCapacity - _currentAmmo;

        if (_allAmo >= reason)
        {
            _allAmo -= reason;
            _currentAmmo = _gunBulletCapacity;
        }
        else
        {
            _currentAmmo = _currentAmmo + _allAmo;
            _allAmo = 0;
        }
    }
}
