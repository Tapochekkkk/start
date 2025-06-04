using UnityEngine;
using UnityEngine.UI;

public class DoorCollisionManager : MonoBehaviour
{
    public GameObject[] doors; // Массив дверей, у которых нужно убрать коллизию
    public Canvas canvas; // Ссылка на Canvas для размещения кнопок
    private GameObject buttonContainer; // Контейнер для кнопок

    private void Start()
    {
        // Создаем контейнер для кнопок
        buttonContainer = new GameObject("ButtonContainer");
        buttonContainer.transform.SetParent(canvas.transform);
        buttonContainer.AddComponent<RectTransform>().sizeDelta = new Vector2(200, 300);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowButtons();
        }
    }

    private void ShowButtons()
    {
        // Удаляем старые кнопки
        foreach (Transform child in buttonContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Создаем новые кнопки
        for (int i = 0; i < doors.Length; i++)
        {
            int index = i; // Локальная переменная для замыкания
            GameObject button = new GameObject("Button" + (i + 1));
            button.transform.SetParent(buttonContainer.transform);

            // Добавляем компоненты для кнопки
            Button btn = button.AddComponent<Button>();
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(180, 40);
            rectTransform.anchoredPosition = new Vector2(0, -i * 50); // Расположение кнопок

            // Создаем текст для кнопки
            GameObject buttonText = new GameObject("Text");
            buttonText.transform.SetParent(button.transform);
            Text text = buttonText.AddComponent<Text>();
            text.text = "Убрать коллизию с дверью " + (i + 1);
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // Используем стандартный шрифт
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;

            // Устанавливаем размер текста
            RectTransform textRectTransform = text.GetComponent<RectTransform>();
            textRectTransform.sizeDelta = new Vector2(180, 40);
            textRectTransform.anchoredPosition = new Vector2(0, 0); // Центрируем текст

            // Добавляем обработчик нажатия на кнопку
            btn.onClick.AddListener(() => RemoveCollision(index));
        }
    }

    private void RemoveCollision(int index)
    {
        if (index >= 0 && index < doors.Length)
        {
            Collider2D doorCollider = doors[index].GetComponent<Collider2D>();
            if (doorCollider != null)
            {
                doorCollider.enabled = false; // Убираем коллизию
                Debug.Log("Коллизия убрана для двери " + (index + 1));
            }
        }
    }
}



