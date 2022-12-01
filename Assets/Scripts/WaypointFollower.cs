using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    //��������� �������� ����
    [SerializeField]
    private GameObject[] _waypoints;
    private int _currentWaypointIndex = 0;

    [SerializeField]
    private float _movingSpeed = 2.5f;

    private void Update()
    {
        //���� ��'��� ��������� �䳺� �����, �� �� ������� �� ��������
        if (Vector2.Distance(_waypoints[_currentWaypointIndex].transform.position,
            transform.position) < .1f)
        {
            _currentWaypointIndex++;
            //���� ����� ����� � ��������� �� ����� ��'����, ����������� �������� ������� ����� 
            if (_currentWaypointIndex >= _waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
        //������� ��������� ��'���� 
        transform.position = Vector2.MoveTowards(transform.position, 
            _waypoints[_currentWaypointIndex].transform.position, Time.deltaTime * _movingSpeed);
    }
}
