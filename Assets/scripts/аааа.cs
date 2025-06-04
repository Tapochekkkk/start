using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public GameObject buttonPrefab; // Префаб кнопки
    public GameObject door; // Дверь, через которую нужно пройти
    public GameObject newPlayerModel; // Новая модель персонажа
    private GameObject buttonInstance; // Экземпляр кнопки
    private bool isButtonActive = false; // Флаг активности кнопки
    private GameObject currentPlayerModel; // Текущая модель персонажа

    void Start()
    {
        // Сохраняем текущую модель персонажа
        currentPlayerModel = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Проверяем нажатие клавиши "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isButtonActive)
            {
                // Если кнопка активна, ничего не делаем
                return;
            }
            else
            {
                ShowButton();
            }
        }
    }

    void ShowButton()
    {
        // Создаем кнопку, если она еще не создана
        if (buttonInstance == null)
        {
            buttonInstance = Instantiate(buttonPrefab, transform.position + Vector3.up, Quaternion.identity);
            buttonInstance.GetComponent<Button>().onClick.AddListener(OnButtonClick);
            isButtonActive = true;
        }
    }

    void OnButtonClick()
    {
        // Отключаем коллайдер двери, чтобы можно было пройти сквозь нее
        Collider doorCollider = door.GetComponent<Collider>();
        if (doorCollider != null)
        {
            doorCollider.enabled = false; // Отключаем коллайдер
        }

        // Удаляем кнопку
        Destroy(buttonInstance);
        isButtonActive = false;

        // Меняем модель персонажа
        if (currentPlayerModel != null)
        {
            Destroy(currentPlayerModel); // Удаляем текущую модель
        }
        Instantiate(newPlayerModel, transform.position, transform.rotation); // Создаем новую модель
    }
}
