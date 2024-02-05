using UnityEngine;
using UnityEngine.UI;

public class StarsScaleController : MonoBehaviour
{
    private Image _scale;   
    private CollectCoin[] _coins;

    public int CoinsQuantity;
    public float Percent;

    private void Awake()
    {
        _scale = GetComponent<Image>();
        _coins = FindObjectsOfType<CollectCoin>();
        CoinsQuantity = _coins.Length;
        _scale.fillAmount = 0;
    }

    void Update()
    {
        if (Statistics.CoinsCollected != 0)
        {
            _scale.fillAmount = (float)Statistics.CoinsCollected / CoinsQuantity;
            Statistics.LevelPercent = _scale.fillAmount * 100;
        }
    }
}
