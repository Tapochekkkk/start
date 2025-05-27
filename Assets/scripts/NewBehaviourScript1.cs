using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    public float jumpForce = 10f; // Сила прыжка
    public Transform groundCheck; // Точка для проверки, находится ли персонаж на земле
    public LayerMask groundLayer; // Слой земли

    private Rigidbody2D rb;
    private bool isGrounded; // Проверка, находится ли персонаж на земле

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Проверка, находится ли персонаж на земле
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Получение ввода для движения
        float moveInput = Input.GetAxis("Horizontal");
        Move(moveInput);

        // Проверка нажатия пробела для прыжка
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void Move(float moveInput)
    {
        // Движение персонажа
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Поворот персонажа в зависимости от направления движения
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Поворот вправо
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Поворот влево
        }
    }

    private void Jump()
    {
        // Прыжок персонажа
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

