using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Sceme name hre";

    public bool isAutomatic = true;
    public bool manualEnter;
    void Start()
    {
        
    }

    void Update()
    {
 
        manualEnter = Input.GetButtonDown("Fire1");

    }

    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        if (otherCollider2D.gameObject.CompareTag("Player") && isAutomatic)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider2D)
    {
        if(otherCollider2D.gameObject.CompareTag("Player"))
        {
            if(!isAutomatic && manualEnter)
            {
                Debug.Log("Teleport");
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
