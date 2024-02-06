using UnityEngine;

public class WinOrLooseController : MonoBehaviour
{
    [SerializeField] private GameObject _youLooseScreen;
    [SerializeField] private GameObject _gameCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GlobalTags.DeathTriggerTag))
        {
            _gameCanvas.SetActive(false);
            _youLooseScreen.SetActive(true);
        }
    }
}