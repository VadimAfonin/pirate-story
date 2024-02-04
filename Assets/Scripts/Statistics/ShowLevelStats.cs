using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLevelStats : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelCoins;
    [SerializeField] private TMP_Text _levelMonsters;


    private void Update()
    {
        _levelCoins.text = Statistics._coinsCollected.ToString();
        _levelMonsters.text = Statistics._enemiesKilled.ToString();
    }
}
