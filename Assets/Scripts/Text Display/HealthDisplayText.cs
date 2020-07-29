using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayText : MonoBehaviour
{
    Text healthText;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerHealth.GetPlayerHealth().ToString();
    }
}
