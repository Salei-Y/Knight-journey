using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //створюємо необхідні змінні
    private Collider2D _playerBox;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private Transform _playerTrans;
    [SerializeField]
    private float _moveSpeed = 8f;
    [SerializeField]
    private float _jumpForce = 10f;

    public Rigidbody2D solidBody;
    public Animator activator;
    private float _dirX = 0f;    
    [SerializeField]
    private AudioSource jumpSoundEffect;
    void Start()
    {
        solidBody = GetComponent<Rigidbody2D>();
        _playerBox = GetComponent<Collider2D>();

        activator = GetComponent<Animator>();

        _playerTrans = GetComponent<Transform>();
    }

    void Update()
    {
        if (solidBody.bodyType == RigidbodyType2D.Dynamic)
        {
            //якщо користувач натиснув кнопки для горизонтального руху, повернути персонажа у потрібний бік
            _dirX = Input.GetAxisRaw("Horizontal");

            solidBody.velocity = new Vector2(_dirX * _moveSpeed, solidBody.velocity.y);

            //якщо користувач натиснув кнопку для стрибку і стоїть на землі, програти звук стрибку і зробити стрибок 
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                jumpSoundEffect.Play();
                solidBody.velocity = new Vector2(solidBody.velocity.x, _jumpForce);
            }

            UpdateAnimationState();// виклик функція для анімації рухів
        }
    }

    //функція для анімації рухів персонажу
    private void UpdateAnimationState()
    {
        MovementState state;
        //якщо персонаж поворухнувся вправо,він біжить
        if (_dirX > 0f)
        {
            state = MovementState.running;
            _playerTrans.localScale = new Vector3(1, 1, 1);
        }
        //якщо персонаж поворухнувся вліво,він біжить
        else if (_dirX < 0f)
        {
            state = MovementState.running;
            _playerTrans.localScale = new Vector3(-1, 1, 1);
        }
        //в іншому випадку персонаж стоїть
        else
        {
            state = MovementState.standing;
        }
        //якщо персонаж стрибнув,то вмикаємо анімацію стрибку
        if (solidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        //якщо персонаж падає,то вмикаємо анімацію падіння
        else if (solidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        activator.SetInteger("state", (int)state);
    }
    //перевірка того чи стоїть гравець на поверхні
    private bool IsGrounded()
    {
        bool isGrounded;

        isGrounded = Physics2D.BoxCast(_playerBox.bounds.center,
            _playerBox.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

        return isGrounded;
    }
}
