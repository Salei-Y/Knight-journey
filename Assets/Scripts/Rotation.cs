using UnityEngine;

public class Rotation : MonoBehaviour
{
    //������ �������� �������� ���������
    [SerializeField] 
    private float _rotationSpeed = 1f;

    private void Update()
    {
        //�������� ��'��� �� ����
        transform.Rotate(0, 0, 360 * _rotationSpeed * Time.deltaTime);
    }
}
