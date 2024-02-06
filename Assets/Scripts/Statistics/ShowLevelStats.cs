using TMPro;
using UnityEngine;

public class ShowLevelStats : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelCoins;
    [SerializeField] private TMP_Text _levelMonsters;

    private void Update()
    {
        _levelCoins.text = Statistics.CoinsCollected.ToString();
        _levelMonsters.text = Statistics.EnemiesKilled.ToString();
    }
}
