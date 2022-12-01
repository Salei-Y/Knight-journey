using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    //створюємо необхідні змінні
    [SerializeField]
    private GameObject[] _waypoints;
    private int _currentWaypointIndex = 0;

    [SerializeField]
    private float _movingSpeed = 2.5f;

    private void Update()
    {
        //якщо об'єкт торкнувся одієї точки, то він рухаєтья до наступної
        if (Vector2.Distance(_waypoints[_currentWaypointIndex].transform.position,
            transform.position) < .1f)
        {
            _currentWaypointIndex++;
            //якщо дійсна точка є останньою на шляху об'єкта, оновлюється лічильник індексів точок 
            if (_currentWaypointIndex >= _waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
        //змінюємо положення об'єкту 
        transform.position = Vector2.MoveTowards(transform.position, 
            _waypoints[_currentWaypointIndex].transform.position, Time.deltaTime * _movingSpeed);
    }
}
