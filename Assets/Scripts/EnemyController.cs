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

    [Tooltip("If enemy movement is not random, enemyDirections needs to have at least two elements")]
    [SerializeField] private bool hasRandomMove;
    [Tooltip("Directions the enemy will follow to complete a path. The idea is that it should be cyclical.Components must be - 1, 0 or 1")]
    [SerializeField] private Vector2[] enemyDirections;
    private int indexDirection;

    private Animator enemyAnimator;

    void Start()
    {
        //enemyAnimator = GetComponent<Animator>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;

        timeBetweenStepsCounter = timeBetweenSteps * (hasRandomMove ? Random.Range(0.5f, 1.5f) : 1);
        timeToMakeStepCounter = timeToMakeStep * (hasRandomMove ? Random.Range(0.5f, 1.5f) : 1);

        directionToMove = hasRandomMove ? new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) : enemyDirections[indexDirection];
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
                if(hasRandomMove)
                {
                    directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                }

                else
                {
                    indexDirection++;
                    if(indexDirection >= enemyDirections.Length)
                    {
                        indexDirection = 0;
                    }
                    directionToMove = enemyDirections[indexDirection];
                }
                //directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            }
        }
    }


    private void LateUpdate()
    {
        //enemyAnimator.SetFloat("Horizontal", _enemyRigidbody.velocity.x);
        //enemyAnimator.SetFloat("Vertical", _enemyRigidbody.velocity.y);
    }
}
