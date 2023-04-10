using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthAmount : MonoBehaviour
{
    [SerializeField]
    private GameObject health;
    private GameObject componentImage;
    private float currentHealth = 1;
    private float newHealth;

    void Start()
    {
        //componentImage = GetComponent<TextMeshProUGUI>();
    }

    public void StartHealth(HealthController healthCount)
    {
        float i, healthDifference;

        currentHealth = healthCount.currentHealth;
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
            componentImage = health.transform.GetChild((int)currentHealth - 1).gameObject;
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
