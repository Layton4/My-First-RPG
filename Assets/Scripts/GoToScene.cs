using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Sceme name hre";

    public bool isAutomatic = true;
    public bool manualEnter;

    public string uuid; //Universal unique identifier


    void Start()
    {
        
    }

    void Update()
    {
        
        manualEnter = Input.GetButtonDown("Fire1");

    }


    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
      Teleport(otherCollider2D.name);
    }

    private void OnTriggerStay2D(Collider2D otherCollider2D)
    {
        Teleport(otherCollider2D.name);
    }

    private void Teleport(string objName)
    {
        if(objName == "Player")
        {
            if(isAutomatic || !isAutomatic && manualEnter)
            {
                FindObjectOfType<PlayerController>().nextUuid = uuid;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
