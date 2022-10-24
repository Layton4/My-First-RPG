using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartPoint : MonoBehaviour
{
    private PlayerController playerControllerScript;
    [SerializeField] private Vector2 facingDirection;

    public string uuid; //uuid means Universal Unique IDENTIFIER

    private CinemachineConfiner2D virtualCameraObject;
    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
        virtualCameraObject = FindObjectOfType<CinemachineConfiner2D>();

        if(!playerControllerScript.nextUuid.Equals(uuid)) //if my uuid don't match the player uuid stop reading the start
        {
            return;
        }
        //if the uuid matches the player uuid it teleport the player
        playerControllerScript.transform.position = transform.position;
        playerControllerScript.lastDirection = facingDirection;

        GameObject confiner = GameObject.Find("Camera Confiner");

        if (confiner != null)
        {
            Debug.Log("Existe el camera confiner");
            virtualCameraObject.m_BoundingShape2D = confiner.GetComponent<PolygonCollider2D>();
        }

    }
    void Update()
    {
        
    }
}
