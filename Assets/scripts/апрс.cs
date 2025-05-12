using UnityEngine;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public GameObject circle; // Ссылка на круг
    public GameObject button; // Ссылка на кнопку

    void Update()
    {
        // Проверяем, нажата ли клавиша "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Переключаем активность круга и кнопки
            bool isActive = !circle.activeSelf;
            circle.SetActive(isActive);
            button.SetActive(isActive);
        }
    }
}

