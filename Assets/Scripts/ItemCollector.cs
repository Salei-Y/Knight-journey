using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //��������� �������� ����
    private int _coins = 0;
    private int _maxCoins = 12;

    [SerializeField]
    private Text _coinsCounter;

    [SerializeField]
    private AudioSource collectSoundEffect;
    //���� �� ��������� ��'����
    private void OnTriggerEnter2D(Collider2D other)
    {
        //���� ��'���, ����� �� ���������� �� ��� "Coin"
        if (other.gameObject.CompareTag("Coin"))
        {
            //�������� ���� � ������� ��'���
            collectSoundEffect.Play();
            Destroy(other.gameObject);
            //�������� �������� ��������� ����� �� 1
            _coins++;
            //������ �����, ���� �������� ������� �����
            _coinsCounter.text = "Coins: " + _coins + "/" + _maxCoins;
        }
        //���� ������ ����. ������� �����, �������� Complete()
        if (_coins == _maxCoins)
        {
            Complete();
        }
    }
    //������� ��� �������� �� �������� �����
    private void Complete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}