using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelthBar : MonoBehaviour
{
    private PlayerController playerControllerScipt;
    private Image healthBarImage;

    void Start()
    {
        playerControllerScipt = FindObjectOfType<PlayerController>();
        healthBarImage = GetComponent<Image>();
    }

    void Update()
    {
        
    }

    public void UpdateHealthBar(float current, float max)
    {
        Debug.Log(current);
        Debug.Log(max);

        healthBarImage.fillAmount = current / max;
    }
}
