using UnityEngine;

public class StickyPlatform : MonoBehaviour
{ 
    //���� ���� ��������� ��'����
    private void OnTriggerEnter2D(Collider2D other)
    { 
        //���� �� "����" �� �������, �� �� �������� � ����������
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    //���� ���� ������� ��������� ��'����
    private void OnTriggerExit2D(Collider2D other)
    {
        //���� �� "����" �� �������, �� �� ������� �������� � ����������
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
