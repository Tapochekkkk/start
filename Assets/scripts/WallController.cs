using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour
{
    public GameObject wall; // Ссылка на стену
    private BoxCollider2D wallCollider; // Коллайдер стены

    void Start()
    {
        // Получаем компонент BoxCollider2D стены
        wallCollider = wall.GetComponent<BoxCollider2D>();
    }

    // Метод для открытия стены
    public void ToggleWall()
    {
        if (wallCollider != null)
        {
            wallCollider.enabled = false; // Отключаем коллайдер
            StartCoroutine(EnableWallAfterTime(1.5f)); // Запускаем корутину для включения коллайдера через 3 секунды
        }
    }

    // Корутину для включения коллайдера через заданное время
    private IEnumerator EnableWallAfterTime(float time)
    {
        yield return new WaitForSeconds(time); // Ждем указанное время
        wallCollider.enabled = true; // Включаем коллайдер
    }
}
