using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthAmount : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject health;

    private GameObject componentImage;
    private HealthController playerHealth;
    private float currentHealth;
    private float newHealth;

    public void Start()
    {
        float i, healthDifference;

        playerHealth = player.GetComponent<HealthController>();

        currentHealth = playerHealth.startingHealth;
        healthDifference = 8 - currentHealth;

        if(currentHealth != 8)
        {
            for(i = 0; i < healthDifference; i++)
            {
                componentImage = health.transform.GetChild((int)i).gameObject;
                componentImage.SetActive(false);
            }
        }
    }

    public void UpdateHealth(HealthController healthCount)
    {
        newHealth = healthCount.currentHealth;

        if(newHealth < currentHealth)
        {
            componentImage = health.transform.GetChild(8 - (int)currentHealth).gameObject;
            componentImage.SetActive(false);
            currentHealth = newHealth;
        }

        else if(newHealth > currentHealth)
        {
            componentImage = health.transform.GetChild(8 - (int)newHealth).gameObject;
            componentImage.SetActive(true);
            currentHealth = newHealth;
        }
    }
}
