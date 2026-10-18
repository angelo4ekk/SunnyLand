using Unity.VisualScripting;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private int gemValue = 1; //Сколько очков дает
    
    //Срабатывает, когда сквозь гем проходит другой коллайдер
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Проверяем: коснулся ли именно персонажа (по тегу "Player")
        if (collision.CompareTag("Player"))
        {
            //1. Добавляем монетку в наш UI
            if (CoinManager.instance != null)
            {
                CoinManager.instance.AddCoins(gemValue);
            }
            //2. Уничтожить объект
            Destroy(gameObject);
        }
    }
}
