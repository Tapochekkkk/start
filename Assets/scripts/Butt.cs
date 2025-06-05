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
        // Если door1Active = true, то включаем коллайдер у door1 и выключаем у door2
        door1Collider.enabled = door1Active;
        door2Collider.enabled = !door1Active;
        
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