using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{

    public int damage;
    public GameObject bloodParticle;
    public GameObject canvasDamageNumber;

    public int index;

    private GameObject hitPoint;

    void Start()
    {
        hitPoint = transform.Find("Hit Point").gameObject;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

            if(bloodParticle != null && hitPoint != null)
            {
                Instantiate(bloodParticle, hitPoint.transform.position, hitPoint.transform.rotation);
            }

            GameObject canvas = Instantiate(canvasDamageNumber, hitPoint.transform.position, Quaternion.identity);
            canvas.GetComponent<DamageNumber>().damagePoints = damage;

        }
    }
}
