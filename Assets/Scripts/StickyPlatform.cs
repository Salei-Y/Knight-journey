using UnityEngine;

public class StickyPlatform : MonoBehaviour
{ 
    //якщо щось торкається об'єкту
    private void OnTriggerEnter2D(Collider2D other)
    { 
        //якщо це "щось" це гравець, то він рухається з платформою
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    //якщо щось перестає торкатися об'єкту
    private void OnTriggerExit2D(Collider2D other)
    {
        //якщо це "щось" це гравець, то він перестає рухаєтись з платформою
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
