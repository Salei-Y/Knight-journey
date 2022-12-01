using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginMenu : MonoBehaviour
{
    //функція для запуску гри
    public void Begin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
