using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginMenu : MonoBehaviour
{
    //������� ��� ������� ���
    public void Begin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
