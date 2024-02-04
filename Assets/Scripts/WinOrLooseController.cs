using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLooseController : MonoBehaviour
{
    [SerializeField] private GameObject _youLooseScreen;
    [SerializeField] private GameObject _gameCanvas;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathTrigger"))
        {
            _gameCanvas.SetActive(false);
            _youLooseScreen.SetActive(true);
        }
    }
}