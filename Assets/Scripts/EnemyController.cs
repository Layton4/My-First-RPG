using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;

    public Vector2 directionToMove;

    private Rigidbody2D _enemyRigidbody;
    private bool isMoving = true; //change

    [Tooltip("Time the enemy takes between sucesive steps")]
    [SerializeField] private float timeBetweenSteps; //Fix time

    //Time since the last step taken by the enemy
    private float timeBetweenStepsCounter; //Time counter CHANGE

    [Tooltip("Time it takes to an enemy to make a step")]
    [SerializeField] private float timeToMakeStep;
    private float timeToMakeStepCounter;

    private Animator enemyAnimator;

    void Start()
    {
        //enemyAnimator = GetComponent<Animator>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }


    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _enemyRigidbody.velocity = speed * directionToMove;

            if (timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                _enemyRigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            }
        }
    }


    private void LateUpdate()
    {
        //enemyAnimator.SetFloat("Horizontal", _enemyRigidbody.velocity.x);
        //enemyAnimator.SetFloat("Vertical", _enemyRigidbody.velocity.y);
    }
}
