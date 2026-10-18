using UnityEngine;
using TMPro; //Подключаем TextMeshPro для текста высокого качетсва

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; //Доступ из любого скрипта
    public TextMeshProUGUI gemText;
    private int totalGem = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void AddCoins(int amount)
    {
        totalGem = totalGem + amount;
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (gemText != null)
        {
            gemText.text = totalGem+"";
        }
    }
}
