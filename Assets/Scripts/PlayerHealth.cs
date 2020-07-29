using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;

    void Start()
    {
        
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public void HealthReduction(GameObject gem)
    {
        DamageDealer damageDealer = gem.GetComponent<DamageDealer>();

        playerHealth -= damageDealer.GetDamage();

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
