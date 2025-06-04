using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons; // Массив кнопок
    public string wallTag; // Тег стены
    private bool buttonsVisible = false; // Состояние видимости кнопок
    private WallController wallController; // Ссылка на WallController

    void Start()
    {
        // Скрываем кнопки при старте
        SetButtonsVisibility(false);
        wallController = FindObjectOfType<WallController>(); // Находим WallController в сцене
    }

    void Update()
    {
        // Проверяем, нажата ли клавиша E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Переключаем видимость кнопок
            buttonsVisible = !buttonsVisible;
            SetButtonsVisibility(buttonsVisible);
        }
    }

    // Метод для установки видимости кнопок
    private void SetButtonsVisibility(bool isVisible)
    {
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.gameObject.SetActive(isVisible); // Включаем или выключаем кнопку
            }
        }
    }

    // Метод для обработки нажатия на кнопку
    public void OnButtonClick(string action)
    {
        if (wallController != null)
        {
            switch (action)
            {
                case "Toggle":
                    wallController.ToggleWallByTag(wallTag);
                    break;
                case "Show":
                    wallController.ShowWallByTag(wallTag);
                    break;
                case "Hide":
                    wallController.HideWallByTag(wallTag);
                    break;
            }
        }
    }
}
