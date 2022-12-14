using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float verticalSpeed = 1f;

    public float scaleFactor = 10f;

    public float damagePoints;

    public TextMeshProUGUI damageText;
    void Start()
    {
        damageText.text = damagePoints.ToString();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + verticalSpeed * Time.deltaTime, 0);
        transform.localScale *= 1 - Time.deltaTime / scaleFactor;
    }
}
