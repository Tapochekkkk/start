using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
    public Transform target; // Объект, за которым будет следовать камера
    public Vector3 offset; // Смещение камеры относительно объекта
    public float smoothSpeed = 0.125f; // Скорость сглаживания движения камеры

    void LateUpdate()
    {
        if (target != null)
        {
            // Вычисляем желаемую позицию камеры
            Vector3 desiredPosition = target.position + offset;
            // Сглаживаем движение камеры
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Устанавливаем позицию камеры
            transform.position = smoothedPosition;
        }
    }
}

