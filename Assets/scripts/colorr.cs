using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour
{
    public Button myButton; // Ссылка на вашу кнопку
    public Animator myAnimator; // Ссылка на ваш Animator

    void Start()
    {
        // Добавляем слушатель нажатия на кнопку
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // Запускаем анимацию
        myAnimator.SetTrigger("color");
    }
}
