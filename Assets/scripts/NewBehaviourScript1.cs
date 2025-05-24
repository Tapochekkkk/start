using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость перемещения персонажа
    private Rigidbody2D rb; // Ссылка на Rigidbody2D
    private Vector2 movement; // Вектор движения

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    private void Update()
    {
        // Получаем ввод с клавиатуры
        movement.x = Input.GetAxisRaw("Horizontal"); // Влево/вправо
        movement.y = Input.GetAxisRaw("Vertical"); // Вверх/вниз
    }

    private void FixedUpdate()
    {
        // Перемещаем персонажа
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
