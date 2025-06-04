using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public WallController wallController; // Ссылка на WallController
    public Button[] buttons; // Массив кнопок

    void Start()
    {
        // Проверяем, что WallController назначен
        if (wallController == null)
        {
            Debug.LogWarning("WallController is not assigned in the Inspector.");
        }

        // Добавляем слушатели для каждой кнопки
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.onClick.AddListener(() => OnButtonClick(button));
            }
            else
            {
                Debug.LogError("Button component not found in the array.");
            }
        }
    }

    // Метод, который вызывается при нажатии на кнопку
    void OnButtonClick(Button clickedButton)
    {
        if (wallController != null)
        {
            // Определяем действие в зависимости от нажатой кнопки
            if (clickedButton.name == "ToggleWallButton")
            {
                wallController.ToggleWall(); // Переключаем стену
            }
            else if (clickedButton.name == "ShowWallButton")
            {
                wallController.ShowWall(); // Показываем стену
            }
            else if (clickedButton.name == "HideWallButton")
            {
                wallController.HideWall(); // Скрываем стену
            }
            // Добавьте дополнительные условия для других кнопок по мере необходимости
        }
    }
}