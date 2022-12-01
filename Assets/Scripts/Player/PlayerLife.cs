using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //створюємо необхідні змінні
    private Rigidbody2D _solidBody;
    private Animator _activator;

    private void Start()
    {
        _solidBody = GetComponent<Rigidbody2D>();
        _activator = GetComponent<Animator>();
    }
    [SerializeField]
    private AudioSource deathSoundEffect;
    //якщо ми торкаємось об'єкту
    private void OnCollisionEnter2D(Collision2D other)
    {
        //якщо об'єкт, якого ми торкнулись має тег "Trap"
        if (other.gameObject.CompareTag("Trap"))
        {
            //програти звук і викликати Die()
            deathSoundEffect.Play();
            Die();
        }
    }
    //забираємо в користувача можливість рухати персонажа і викликаємо анімацію смерті
    private void Die()
    {
        _solidBody.bodyType = RigidbodyType2D.Static;

        _activator.SetTrigger("death");
    }
    //функція перезапуску рівня
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
