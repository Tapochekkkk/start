using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public WallController wallController; // Ссылка на WallController

    void Start()
    {
        // Получаем компонент Button и добавляем слушатель
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    // Метод, который вызывается при нажатии на кнопку
    void OnButtonClick()
    {
        if (wallController != null)
        {
            wallController.ToggleWall(); // Вызываем метод ToggleWall из WallController
        }
    }
}
