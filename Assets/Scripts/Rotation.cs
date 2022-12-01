using UnityEngine;

public class Rotation : MonoBehaviour
{
    //задаємо значення швидкості обертання
    [SerializeField] 
    private float _rotationSpeed = 1f;

    private void Update()
    {
        //обертаємо об'єкт по колу
        transform.Rotate(0, 0, 360 * _rotationSpeed * Time.deltaTime);
    }
}
