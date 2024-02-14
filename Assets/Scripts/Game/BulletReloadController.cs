using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BulletReloadController : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentAmmoText;
    [SerializeField] private Image _filledImage;
    [SerializeField] private int _allAmo; //в запасе (сколько всего патронов с собой)
    [SerializeField] private int _gunBulletCapacity; //емкость барабана
    [SerializeField] private float _animationCooldown;

    private Animator _anim;

    private bool _isReloading = false;
    private bool _isShotAllowed;
    private bool _isReloadAllowed;
    private bool _isShootingAnimationIsPlaying = false;

    private int _currentAmmo; //в рожке 

    private void Awake()
    {
        _currentAmmo = _gunBulletCapacity;
        _anim = GetComponent<Animator>();
        _filledImage.fillAmount = 0;
    }

    private void Update()
    {
        _isShotAllowed = _currentAmmo > 0 && !_isReloading && !PauseController.IsPaused && !_isShootingAnimationIsPlaying;
        _isReloadAllowed = _allAmo > 0 && _currentAmmo != _gunBulletCapacity;

        _currentAmmoText.text = (_currentAmmo + " / " + _allAmo);

        if (Input.GetButtonDown(GlobalStringVars.Fire1) && _isShotAllowed)
        {
            _anim.SetTrigger(AnimatorConstants._isShootingProperty);
            StartCoroutine(WaitForShootAnimation());
            _currentAmmo--;

            if (_currentAmmo <= 0)
            {
                _currentAmmo = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && _isReloadAllowed)
        {
            Reload();
        }

        if (_isReloading)
        {
            _filledImage.fillAmount += Time.fixedDeltaTime / 2;

            if (Mathf.Abs(1 - _filledImage.fillAmount).IsEqualsZero())
            {
                _isReloading = false;
                _filledImage.fillAmount = 0;
            }
        }
    }

    private void Reload()
    {
        _isReloading = true;

        int reason = _gunBulletCapacity - _currentAmmo; //разница между текущим количеством в обойме и её вместимостью

        if (_allAmo >= reason)
        {
            _allAmo -= reason;
            _currentAmmo = _gunBulletCapacity;
        }
        else
        {
            _currentAmmo += _allAmo;
            _allAmo = 0;
        }
    }

    private IEnumerator WaitForShootAnimation()
    {
        _isShootingAnimationIsPlaying = true;
        yield return new WaitForSeconds(_animationCooldown);
        _isShootingAnimationIsPlaying = false;
    }
}
