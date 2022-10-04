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

    void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);

        if(Mathf.Abs(xInput) > inputTol || Mathf.Abs(yInput) > inputTol)
        {
            Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            //translation.y = yInput * speed * Time.deltaTime;
            transform.Translate(translation);
        }

        if (Mathf.Abs(yInput) > inputTol)
        {
            Vector3 translation_y = new Vector3(0, yInput * speed * Time.deltaTime, 0);
            transform.Translate(translation_y);
        }
        
    }
}
