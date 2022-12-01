using UnityEngine;

public class CameraController : MonoBehaviour
{
    //отримуЇмо значенн€ положенн€ гравц€
    [SerializeField]
    private Transform _player;

    private void Update()
    {
        //перем≥щаЇмо камеру всл≥д за гравцем
        transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
    }
}
