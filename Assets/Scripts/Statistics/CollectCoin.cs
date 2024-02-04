using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    //[SerializeField] private AudioSource _collectSound;
    [SerializeField] private GameObject _coin;

    private bool _isCollected;

    private void Start()
    {
        //_collectSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.name.Equals("Player"))// && !_isCollected)
        {
           // _collectSound.PlayOneShot(_collectSound.clip);
            Statistics._coinsCollected++;
            Destroy(_coin, 0.35f);
            _isCollected = true;
        }
    }
}
