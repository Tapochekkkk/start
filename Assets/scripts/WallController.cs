using UnityEngine;

public class WallController : MonoBehaviour
{
    // Метод для переключения видимости стены по тегу
    public void ToggleWallByTag(string tag)
    {
        GameObject wall = GameObject.FindGameObjectWithTag(tag);
        if (wall != null)
        {
            bool isActive = wall.activeSelf;
            wall.SetActive(!isActive); // Переключаем видимость
        }
    }

    // Метод для показа стены по тегу
    public void ShowWallByTag(string tag)
    {
        GameObject wall = GameObject.FindGameObjectWithTag(tag);
        if (wall != null)
        {
            wall.SetActive(true); // Показываем стену
        }
    }

    // Метод для скрытия стены по тегу
    public void HideWallByTag(string tag)
    {
        GameObject wall = GameObject.FindGameObjectWithTag(tag);
        if (wall != null)
        {
            wall.SetActive(false); // Скрываем стену
        }
    }
}
