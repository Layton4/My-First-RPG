using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int expWhenDefeated;

    public int maxHealth = 100;
    [SerializeField] private int currentHealth;


    private bool isBlinking;
    [SerializeField] private float blinkingDuration;
    private float blinkingCounter;
    private SpriteRenderer _characterRenderer;

    private HelthBar HelthBarScript;

    void Start()
    {
        HelthBarScript = FindObjectOfType<HelthBar>();
        //HelthBarScript.UpdateHealthBar(currentHealth, maxHealth);

        _characterRenderer = GetComponent<SpriteRenderer>();
        UpdateMaxHealth(maxHealth);
    }


    void Update()
    {
        if (isBlinking)
        {
            blinkingCounter -= Time.deltaTime;
            if (blinkingCounter > blinkingDuration * 0.8) //80%
            {
                ToggleColor(false);
            }
            else if (blinkingCounter > blinkingDuration * 0.6) //60%
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > blinkingDuration * 0.4) //40%
            {
                ToggleColor(false);

            }
            else if (blinkingCounter > blinkingDuration * 0.2) //20%
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > 0) //0%
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                isBlinking = false;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlayerController>().canMove = true;
            }
        }

    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            if(gameObject.tag.Equals("Enemy"))
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);
            }
            gameObject.SetActive(false);
        }

        if (blinkingDuration > 0)
        {
        
            isBlinking = true;
            blinkingCounter = blinkingDuration;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
            HelthBarScript.UpdateHealthBar(currentHealth, maxHealth);

        }
    }

    private void ToggleColor(bool isVisible)
    {
        Color color = _characterRenderer.color;
        color = new Color(color.r, color.g, color.b, isVisible ? 1 : 0); //if visible true vale 1, if visible false vale 0
        _characterRenderer.color = color;
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
        HelthBarScript.UpdateHealthBar(currentHealth, maxHealth);
    }

}
