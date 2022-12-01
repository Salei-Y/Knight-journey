using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //��������� �������� ����
    private Rigidbody2D _solidBody;
    private Animator _activator;

    private void Start()
    {
        _solidBody = GetComponent<Rigidbody2D>();
        _activator = GetComponent<Animator>();
    }
    [SerializeField]
    private AudioSource deathSoundEffect;
    //���� �� ��������� ��'����
    private void OnCollisionEnter2D(Collision2D other)
    {
        //���� ��'���, ����� �� ���������� �� ��� "Trap"
        if (other.gameObject.CompareTag("Trap"))
        {
            //�������� ���� � ��������� Die()
            deathSoundEffect.Play();
            Die();
        }
    }
    //�������� � ����������� ��������� ������ ��������� � ��������� ������� �����
    private void Die()
    {
        _solidBody.bodyType = RigidbodyType2D.Static;

        _activator.SetTrigger("death");
    }
    //������� ����������� ����
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
