using UnityEngine;
using TMPro;

public class TotalScoresPrinter : MonoBehaviour
{
    [SerializeField] private TMP_Text _totalCoinsText;
    [SerializeField] private TMP_Text _totalMonsterText;
    [SerializeField] private TMP_Text _total_livesText;

    private void Update()
    {
        _totalCoinsText.text = Statistics.CoinsCollectedTotal.ToString();
        _totalMonsterText.text = Statistics.EnemiesKilledTotal.ToString();
        _total_livesText.text = Statistics.LivesUsed.ToString();
    }
}