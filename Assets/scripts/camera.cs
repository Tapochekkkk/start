using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
    public Transform target; // ������, �� ������� ����� ��������� ������
    public Vector3 offset; // �������� ������ ������������ �������
    public float smoothSpeed = 0.125f; // �������� ����������� �������� ������

    void LateUpdate()
    {
        if (target != null)
        {
            // ��������� �������� ������� ������
            Vector3 desiredPosition = target.position + offset;
            // ���������� �������� ������
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // ������������� ������� ������
            transform.position = smoothedPosition;
        }
    }
}

