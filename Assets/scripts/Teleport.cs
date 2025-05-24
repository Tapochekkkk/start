using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Teleport2D : MonoBehaviour
{
    public Image fadeImage; // Ссылка на Image для затемнения
    public Transform targetPosition; // Целевая позиция для перемещения

    private void Start()
    {
        // Убедитесь, что изображение полностью прозрачно в начале
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Убедитесь, что триггер сработал для игрока
        {
            StartCoroutine(Transition(other.transform));
        }
    }

    private IEnumerator Transition(Transform player)
    {
        // Затемняем экран
        float fadeTime = 1f; // Время затемнения
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Clamp01(t / fadeTime);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Перемещаем игрока
        player.position = targetPosition.position;

        // Затемняем экран обратно
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            float alpha = Mathf.Clamp01(1 - (t / fadeTime));
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
