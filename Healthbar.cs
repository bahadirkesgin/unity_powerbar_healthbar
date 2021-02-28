using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour { 
    public float playerHealth = 100f; // connect to your player health controller
    public float currentBarLevel = 0f; 
    public Slider healthbar;

    void Start() {
        healthbar.maxValue = 100;
        healthbar.minValue = 0;
    }
    void Update() 
    {    
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }
        else if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        HealthbarUpdate(playerHealth)
    }

    void HealthbarUpdate(float health)
    {
        healthbar.value = health;
    }
}