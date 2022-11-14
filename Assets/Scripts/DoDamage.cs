using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public float timeToRevivePlayer;
    private float timeRevivalCounter;
    private bool isPlayerReviving;
    private GameObject player;

    public int damage = 10;

    // Update is called once per frame
    void Update()
    {
        /*
        if(isPlayerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if(timeRevivalCounter <= 0)
            {
                isPlayerReviving = false;
                player.SetActive(true);
            }
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.name == "Player")
        {
            /*
            //Debug.Log("TomaGolpe");
            player = otherCollider.gameObject;
            player.SetActive(false);
            isPlayerReviving = true;
            timeRevivalCounter = timeToRevivePlayer;
            */
            otherCollider.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

        }
    }
}
