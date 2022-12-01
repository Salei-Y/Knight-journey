using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //��������� �������� ����
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
            //���� ���������� �������� ������ ��� ��������������� ����, ��������� ��������� � �������� ��
            _dirX = Input.GetAxisRaw("Horizontal");

            solidBody.velocity = new Vector2(_dirX * _moveSpeed, solidBody.velocity.y);

            //���� ���������� �������� ������ ��� ������� � ����� �� ����, �������� ���� ������� � ������� ������� 
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                jumpSoundEffect.Play();
                solidBody.velocity = new Vector2(solidBody.velocity.x, _jumpForce);
            }

            UpdateAnimationState();// ������ ������� ��� ������� �����
        }
    }

    //������� ��� ������� ����� ���������
    private void UpdateAnimationState()
    {
        MovementState state;
        //���� �������� ������������ ������,�� �����
        if (_dirX > 0f)
        {
            state = MovementState.running;
            _playerTrans.localScale = new Vector3(1, 1, 1);
        }
        //���� �������� ������������ ����,�� �����
        else if (_dirX < 0f)
        {
            state = MovementState.running;
            _playerTrans.localScale = new Vector3(-1, 1, 1);
        }
        //� ������ ������� �������� �����
        else
        {
            state = MovementState.standing;
        }
        //���� �������� ��������,�� ������� ������� �������
        if (solidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        //���� �������� ����,�� ������� ������� ������
        else if (solidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        activator.SetInteger("state", (int)state);
    }
    //�������� ���� �� ����� ������� �� �������
    private bool IsGrounded()
    {
        bool isGrounded;

        isGrounded = Physics2D.BoxCast(_playerBox.bounds.center,
            _playerBox.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

        return isGrounded;
    }
}
