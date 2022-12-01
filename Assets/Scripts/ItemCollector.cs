using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //створюємо необхідні змінні
    private int _coins = 0;
    private int _maxCoins = 12;

    [SerializeField]
    private Text _coinsCounter;

    [SerializeField]
    private AudioSource collectSoundEffect;
    //якщо ми торкаємось об'єкту
    private void OnTriggerEnter2D(Collider2D other)
    {
        //якщо об'єкт, якого ми торкнулись має тег "Coin"
        if (other.gameObject.CompareTag("Coin"))
        {
            //програти звук і знищити об'єкт
            collectSoundEffect.Play();
            Destroy(other.gameObject);
            //збільшити значення лічильника монет на 1
            _coins++;
            //змінити текст, який відображає кількість монет
            _coinsCounter.text = "Coins: " + _coins + "/" + _maxCoins;
        }
        //якщо зібрано макс. кількість монет, виконати Complete()
        if (_coins == _maxCoins)
        {
            Complete();
        }
    }
    //функція для переходу на наступну сцену
    private void Complete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}