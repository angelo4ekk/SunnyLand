using UnityEngine; // Эту строчку нужно добавить, чтобы Unity понимала команды вроде Vector2, Input и т.д.

// Обертка в класс. Название класса (player) должно совпадать с названием файла (player.cs)
public class player : MonoBehaviour 
{
    [Header("Настройка движения")]
    public float speed = 5f; //Скорость бега
    public float jumpForce = 12f; //Сила прыжка

    [Header("Проверка земли")]
    public Transform groundCheck; //Точка под ногами персонажа
    private float groundCheckRadius = 0.2f; //Радиус круга сенсора
    public LayerMask groundLayer; //Слой земли

    private Animator anim; // Добавили аниматор
    private Rigidbody2D rb; // Подключаем физику (ИСПРАВЛЕНА ОПЕЧАТКА: Rigidbody2D)
    private float horizontal_input; //Переменная для движения по оси X
    private bool isGrounded; //Переменная для проверки земли

    void Start()
    {
        //Находим компонент физики один раз при старте
        rb = GetComponent<Rigidbody2D>(); 
        //Находим компонент Animator
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Считываем нажатия клавиш (по горизонтали то есть вправо и влево)
        horizontal_input = Input.GetAxisRaw("Horizontal");
        
        //Задаем движение персонажа с помощью физик по оси х, а по оси Y сохраняем
        rb.linearVelocity = new Vector2(horizontal_input * speed, rb.linearVelocity.y);
        
        //Разворачиваем персонажа
        Flip();
        
        //Проверяем стоит ли на земле
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
        
        //Прыгаем, только если нажат Пробел и персонаж на земле!
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (anim != null)
        {
            anim.SetFloat("speed", Mathf.Abs(horizontal_input));
            anim.SetBool("IsGround", isGrounded);
        }
    }

    private void Flip()
    {
        if (horizontal_input > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontal_input < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    //Рисуем красный шарик под ногами в окне Scene для настройки
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
} // Закрывающая скобка класса