using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prince
{

    #region Attributes
    private bool _isHuman;
    private bool _isRaven;
    private bool _isMoving;
    private bool _isAlive;
    private bool _isAttacking;
    private bool _isFlyingHigh;
    private bool _isFlyingDown;
    private Rigidbody2D _body;
    private Animator _animator;
    private float _scaleValue;
    private float _walkSteps;
    private float _flySteps;
    private bool _isTalking;
    private int _dialogSequence;
    #endregion

    #region Constructors
    public Prince()
    {
    }

    #endregion

    #region Setters and Getters
    public float ScaleValue { get => _scaleValue; set => _scaleValue = value; }
    public float WalkSteps { get => _walkSteps; set => _walkSteps = value; }
    public float FlySteps { get => _flySteps; set => _flySteps = value; }
    public bool IsHuman { get => _isHuman; set => _isHuman = value; }
    public bool IsRaven { get => _isRaven; set => _isRaven = value; }
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    public bool IsAlive { get => _isAlive; set => _isAlive = value; }
    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }
    public bool IsFlyingHigh { get => _isFlyingHigh; set => _isFlyingHigh = value; }
    public bool IsFlyingDown { get => _isFlyingDown; set => _isFlyingDown = value; }
    public Animator animator { get => _animator; set => _animator = value; }
    public Rigidbody2D body { get => _body; set => _body = value; }
    
    #endregion

    #region Prince actions

    #endregion

}

public class Player : MonoBehaviour
{
    #region Instances
    public Prince prince;
    public float _walkSteps;
    public float _flySteps;
    private Vector3 startPosition;

    #endregion

    void Start()
    {
        prince = new Prince()
        {
            IsHuman = true,
            IsAlive = true,
            IsMoving = false,
            IsRaven = false,
            IsAttacking = false,
            IsFlyingDown = false,
            IsFlyingHigh = false,
            ScaleValue = transform.localScale.x,
            WalkSteps = _walkSteps,
            FlySteps = _flySteps,
            animator = GetComponent<Animator>(),
            body = GetComponent<Rigidbody2D>()
        };

        startPosition = new Vector3(0, 0, 0);
        transform.position = startPosition;

    }

    void Update()
    {
        UpdatePrinceActions();

        if (prince.IsAlive)
        {
            Transform();
            Attack();
            Move();
            //Shoot();
            //Hit();
            //Suffer();
        }
        else {
            //GameOver(); 
        }

    }

    private void UpdatePrinceActions()
    {
        if (prince.IsAlive)
        {
            prince.IsMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
            prince.IsHuman = !Input.GetKey(KeyCode.LeftShift);
            prince.IsRaven = Input.GetKey(KeyCode.LeftShift);
            prince.IsAttacking = Input.GetKey(KeyCode.Z);
        }
        
    }
    private void Transform()
    {

        prince.animator.SetBool("raven", prince.IsRaven && !prince.IsHuman);
        prince.animator.SetBool("flying_high", prince.IsFlyingHigh);
        prince.animator.SetBool("flying_low", prince.IsFlyingDown);

    }
    private void Attack()
    {
        
        prince.animator.SetBool("attack", prince.IsAttacking);

    }

    private void Move()
    {
        float _movX = Input.GetAxisRaw("Horizontal");
        float _movY = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(_movX, _movY, 0);
        float velocity = prince.IsRaven ? prince.FlySteps : prince.WalkSteps;

        float posX = transform.position.x + moveDirection.x * Time.deltaTime * velocity;
        float posY = transform.position.y + moveDirection.y * Time.deltaTime * velocity;
        Vector2 move = new Vector2(posX, posY);

        prince.animator.SetBool("walk", prince.IsMoving);

        prince.body.MovePosition(move);
        Turn(_movX, _movY);

    }

    private void Turn(float _movX, float _movY)
    {
        Vector3 characterScale = transform.localScale;

        bool left = _movX < 0;
        bool down = _movY < 0;
        bool right = _movX > 0;
        bool up = _movY > 0;

        prince.IsFlyingHigh = up && right || up && left;
        prince.IsFlyingDown = down && right || down && left;

        if ((left && down) || (left && up))
        {
            characterScale.x = prince.ScaleValue;
        }
        else if ((right && down) || (right && up))
        {
            characterScale.x = -prince.ScaleValue;
        }
        else if (left || down)
        {
            characterScale.x = prince.ScaleValue;
        }
        else if (right || up)
        {
            characterScale.x = -prince.ScaleValue;
        }

        transform.localScale = characterScale;
    }

}
