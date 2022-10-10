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

    #region ClaseMartes
    private bool isWalking = false;
    private Vector2 lastMovement = Vector2.zero;
    private Animator playerAnimator;
    public const string LASTH = "LastHorizontal", LASTV = "LastVertical";
    #endregion

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        isWalking = false;
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);

        if(Mathf.Abs(xInput) > inputTol)
        {
            Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            //translation.y = yInput * speed * Time.deltaTime;
            transform.Translate(translation);

            isWalking = true;
        }

        if (Mathf.Abs(yInput) > inputTol)
        {
            Vector3 translation_y = new Vector3(0, yInput * speed * Time.deltaTime, 0);
            transform.Translate(translation_y);

            isWalking = true;
        }
        
    }
    
    private void LateUpdate()
    {
        playerAnimator.SetFloat(HORIZONTAL, xInput);
        playerAnimator.SetFloat(VERTICAL, yInput);

        playerAnimator.SetBool("IsWalking", isWalking);
        playerAnimator.SetFloat(LASTH, lastMovement.x);
        playerAnimator.SetFloat(LASTV, lastMovement.y);
    }
    
}
