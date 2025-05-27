using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform spawnPoint; // Точка респавна
    public Animator animator; // Компонент Animator
    public float respawnDelay = 2f; // Задержка перед респавном

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, столкнулся ли персонаж с объектом, который вызывает смерть
        if (other.CompareTag("Enemy")) // Убедитесь, что у врагов установлен тег "Enemy"
        {
            Debug.Log("Player has died!"); // Отладочное сообщение
            Die();
        }
    }

    private void Die()
    {
        // Воспроизведение анимации смерти
        animator.SetTrigger("Die");
        
        // Запуск корутины для респавна
        StartCoroutine(Respawn());
    }

    private System.Collections.IEnumerator Respawn()
    {
        // Ждем указанное время
        yield return new WaitForSeconds(respawnDelay);
        
        // Респавн персонажа
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        // Воспроизведение анимации появления
        animator.SetTrigger("Respawn");
    }
}

