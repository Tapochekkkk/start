using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour
{
    public Button myButton; // ������ �� ���� ������
    public Animator myAnimator; // ������ �� ��� Animator

    void Start()
    {
        // ��������� ��������� ������� �� ������
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // ��������� ��������
        myAnimator.SetTrigger("color");
    }
}
