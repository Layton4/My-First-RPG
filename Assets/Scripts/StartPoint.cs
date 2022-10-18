using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private PlayerController playerControllerScript;
    [SerializeField] private Vector2 facingDirection;
    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
        playerControllerScript.transform.position = transform.position;

        playerControllerScript.lastDirection = facingDirection;
    }
    void Update()
    {
        
    }
}
