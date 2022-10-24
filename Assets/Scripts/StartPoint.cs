using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private PlayerController playerControllerScript;
    [SerializeField] private Vector2 facingDirection;

    public string uuid; //uuid means Universal Unique IDENTIFIER
    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        if(!playerControllerScript.nextUuid.Equals(uuid)) //if my uuid don't match the player uuid stop reading the start
        {
            return;
        }
        //if the uuid matches the player uuid it teleport the player
        playerControllerScript.transform.position = transform.position;
        playerControllerScript.lastDirection = facingDirection;
    }
    void Update()
    {
        
    }
}
