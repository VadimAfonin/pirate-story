using UnityEngine;
using UnityEngine.UI;

public class StarsScaleController : MonoBehaviour
{
    private Image _scale;
    public int coinsQuantity;
    public float percent;
    private CollectCoin[] _coins;

    private void Awake()
    {
        _scale = GetComponent<Image>();
        _coins = FindObjectsOfType<CollectCoin>();
        coinsQuantity = _coins.Length;
        _scale.fillAmount = 0;
    }

    void Update()
    {
        if (Statistics._coinsCollected != 0)
        {
            _scale.fillAmount = (float)Statistics._coinsCollected / coinsQuantity;
            Statistics._levelPercent = _scale.fillAmount * 100;
        }
    }
}
