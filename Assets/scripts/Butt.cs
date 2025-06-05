using UnityEngine;
using UnityEngine.UI;

public class AdvancedDoorController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject buttonPanel;
    public Button door1Button;
    public Button door2Button;

    [Header("Door Colliders")]
    public Collider2D door1Collider; // Коллайдер первой двери
    public Collider2D door2Collider; // Коллайдер второй двери

    [Header("Player Models")]
    public GameObject defaultPlayerModel;
    public GameObject door1PlayerModel;
    public GameObject door2PlayerModel;

    private bool isPanelActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleButtonPanel();
        }
    }

    void Start()
    {
        // Инициализация
        buttonPanel.SetActive(false);
        
        // Назначаем действия для кнопок
        door1Button.onClick.AddListener(() => ToggleDoors(true));
        door2Button.onClick.AddListener(() => ToggleDoors(false));
        
        // Активируем дефолтную модель и деактивируем остальные
        defaultPlayerModel.SetActive(true);
        door1PlayerModel.SetActive(false);
        door2PlayerModel.SetActive(false);
    }

    void ToggleButtonPanel()
    {
        isPanelActive = !isPanelActive;
        buttonPanel.SetActive(isPanelActive);
        
        // Пауза игры при открытом меню (опционально)
        Time.timeScale = isPanelActive ? 0f : 1f;
    }

    void ToggleDoors(bool door1Active)
    {
        // Управление коллайдерами дверей
        door1Collider.enabled = door1Active;
        door2Collider.enabled = !door1Active;
        
        // Смена модели персонажа
        if (door1Active)
        {
            defaultPlayerModel.SetActive(false);
            door1PlayerModel.SetActive(true);
            door2PlayerModel.SetActive(false);
        }
        else
        {
            defaultPlayerModel.SetActive(false);
            door1PlayerModel.SetActive(false);
            door2PlayerModel.SetActive(true);
        }
        
        Debug.Log(door1Active ? "Дверь 1 активна, дверь 2 неактивна" : "Дверь 2 активна, дверь 1 неактивна");
        
        ClosePanel();
    }

    void ClosePanel()
    {
        isPanelActive = false;
        buttonPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}