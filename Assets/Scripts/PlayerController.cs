using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement 
    public float speed = 5f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";

    private float inputTol = 0.2f; //if we press 0.2 or less of input a key we want to ignore it, is the input tolerance, min: 20% pressed:

    public float xInput, yInput;

    private Rigidbody2D _playerRigidbody;

    //Animation Player
    private bool isWalking = false;
    public Vector2 lastDirection = Vector2.zero;
    private Animator _animator;
    public const string LASTH = "LastHorizontal", LASTV = "LastVertical";


    public string nextUuid;

    public static bool playerCreated;

    private bool isAttacking;
    [SerializeField] private float attackTime;
    private float attackTimeCounter;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerCreated = true;
    }
    void Update()
    {
        isWalking = false;
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);

        if (isAttacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                isAttacking = false;
            }

        }

        else if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            attackTimeCounter = attackTime;
        }

        else
        {
            Movement();
        }
        
    }
    
    private void LateUpdate()
    {
        if (!isWalking || isAttacking)
        {
            _playerRigidbody.velocity = Vector2.zero;
        }

        _animator.SetFloat(HORIZONTAL, xInput);
        _animator.SetFloat(VERTICAL, yInput);

        
        _animator.SetFloat(LASTH, lastDirection.x);
        _animator.SetFloat(LASTV, lastDirection.y);

        _animator.SetBool("IsWalking", isWalking);

        _animator.SetBool("IsAttacking", isAttacking);

    }

    private void Movement()
    {
        //Horizontal Movement
        if (Mathf.Abs(xInput) > inputTol)
        {
            Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            //translation.y = yInput * speed * Time.deltaTime;
            //transform.Translate(translation);
            _playerRigidbody.velocity = new Vector2(xInput * speed, 0);

            isWalking = true;
            lastDirection = new Vector2(xInput, 0);
        }

        //Vertical Movement
        if (Mathf.Abs(yInput) > inputTol)
        {
            Vector3 translation_y = new Vector3(0, yInput * speed * Time.deltaTime, 0);
            //transform.Translate(translation_y);
            _playerRigidbody.velocity = new Vector2(0, yInput * speed);

            isWalking = true;
            lastDirection = new Vector2(0, yInput);
        }
    }

}
